using UnityEngine;
using System.Collections;

public enum SKILL_APPEAR
{
    SA_ROLL = 0, // սʿ �����ַ���
    SA_MAG_FLASH_AWAY,      // ��ʦ����
    SA_MAG_FLASH_BACK,          // ��ʦ���� �����м�һ��
    SA_WHIRL_WIND,
    SA_FIRE_RAIN,
    //SA_ENERGE_WAVE,
    SA_FLASH_AWAY,      // �粼������
}

public class SkillAppear : Appear 
{
    public int skill_id;

    public SkillExpressionDataItem m_kSkillInfo;
    public SkillDataItem m_kData;

    protected float m_fUpdateTime = 0.0f;

    public float m_fSkillCD = 0.0f;

    // �����˺����ܵ�һ�ε��˺���λ�ж�
    public bool m_bDurationalSkillFirstClearFlag = true;

    // �����˺����ܵ�һ�ε���ײ���ж�
    public bool m_bDurationalSkillFirstColliderFlag = true;


    // ���������Լ���ͨ�����Ƿ���������
    public int m_nColliderStopValue = 1;

    public bool m_bSkillIntrupted = false;


	public bool m_bSkillTriggedJiGuan = false;

    public SkillAppear(int skillid)
    {
        battle_state = Appear.BATTLE_STATE.BS_SKILL;
        skill_id = skillid;
    }

    public virtual void init()
    {
        if (skill_id != 0)
        {
            loadConfig();
        }
    }
	
	public virtual int GetSkillId() 
    {
		return skill_id;
	}
	
	public float getAttackRepel() 
    {
		return get_repel_inner();
	}
	
	public float getAttackFly() 
    {
		return get_fly_inner();
	}

	
	public int getMPCost() 
    {
        return m_kData.mp_cost;
	}

	
	public int getCoolDown() 
    {
        return m_kData.cool_down;
	}

    public float GetSkillLife()
    {
        if (m_kData.lastTick != 0)
        {
            return m_kData.lastTick ;
        }

        return time_length;
    }

    public float GetLeftTime()
    {
        return GetSkillLife() - m_fUpdateTime;
    }
	
    //public float getLife() {
    //    return m_kData.life;
    //}
	
	public float getLastTick() {
        return m_kData.lastTick;
	}
	
    //public int getAddValue() {
    //    return m_kData.addStateValue;
    //}
	
	public virtual float GetAttackCoefficient() 
    {
        return m_kData.attack_coefficient;
	}

    public virtual float GetDamagePlus()
    {
        return m_kData.damage_plus;
    }


    public static int ConvertLevelIDToSingleID(int levelID)
    {
        return levelID / 1000;
    }

	public void loadConfig() 
    {
       m_kData  = ConfigDataManager.GetInstance().getSkillConfig().getSkillData(skill_id);
       m_kSkillInfo = ConfigDataManager.GetInstance().getSkillExpressionConfig().getSkillExpressionData(ConvertLevelIDToSingleID(skill_id));
	}

    // ���ܵĹ�����Χ
    public float GetSkillRange()
    {
        return m_kData.attack_range;
    }

    // �����Ƿ���������
    public bool LockEnemy()
    {
        return m_kData.suo_target == 1;
    }

    // �����Ƿ����ƽ��
    public bool NoTargetCast()
    {
        return m_kData.no_target == 1;
    }

    public override void active()
    {
        // ��λʱ������ɼ������� (ÿ�����ʩ�ŵļ���)
        animation_name = m_kSkillInfo.skillAction;
        //Debug.Log("SSSKKKIIILLL " + animation_name + " " + m_kSkillInfo.id);
        //owner.animation[animation_name].speed = 1.0f;

        m_fSkillCD = m_kData.cool_down;

        // ѭ������ 
        if (m_kSkillInfo.SpecialEffectLoop != 0)
        {
            time_length = m_kData.lastTick;
        }
        else
            time_length = owner.animation[animation_name].length;


        PlayerSpecialEffect();

        on_active(time_length);

        owner.skill.setCurrentSkill(this);

        m_fUpdateTime = 0.0f;
        m_nColliderStopValue = 1;

		m_bSkillTriggedJiGuan = false;

        // ����������л����ͷ�ʱ��������� ��Ҫ�����ﴥ��
        BattleJiGuan.Instance.OnJiGuanTrigger(JiGuanItem.EJiGuanType.JGT_SKILL_BEGIN, m_kSkillInfo.nJiGuanID, owner.transform.position, this);
        
        if (!Global.inMultiFightMap() || CharacterPlayer.character_property.getHostComputer() || owner.getType() != CharacterType.CT_MONSTER)
        {
            // �ż���֮ǰ�ѽ�ɫ����ָ�������
            if (owner != null && owner.skill != null && owner.skill.getSkillTarget() != null && battle_state == BATTLE_STATE.BS_SKILL)
            {
                if (m_kData.qishou)
                {
                    Vector3 dir = owner.skill.getSkillTarget().transform.position - owner.transform.position;
                    dir.Normalize();
                    owner.setFaceDir(dir);

                    return;
                }
            }

            if (owner != null && owner.skill != null && owner.skill.getSkillTarget() != null && battle_state == BATTLE_STATE.BS_PING_KAN)
            {
                Vector3 dir = owner.skill.getSkillTarget().transform.position - owner.transform.position;
                dir.Normalize();
                owner.setFaceDir(dir);

                return;
            }
        }
    }

	protected override bool IsLoopAnimation()
    {
        return m_kSkillInfo.SpecialEffectLoop != 0;
    }

    protected override void on_deActive()
    {
        base.on_deActive();

        owner.skill.setCurrentSkill(null);  

        // ��Ӽ��ܵ�buff

        // ÿ����յ�����������նλ��
        if (owner.getType() == CharacterType.CT_PLAYEROTHER)
        {
            CharacterPlayerOther other = owner as CharacterPlayerOther;

            other.m_kXuanFengZhanPos.Clear();
            other.m_kCommonAttackPos.Clear();
        }
    }

    public override void update(float delta)
    {
        m_fUpdateTime += delta;

        if (m_fUpdateTime > time_length)
        {
            if (m_kData.nextSkill != 0)
            {
                if (Global.inMultiFightMap() && !CharacterPlayer.character_property.getHostComputer() && owner.getType() == CharacterType.CT_MONSTER)
                {
                    owner.ChangeAppear(owner.skill.CreateSkill(m_kData.nextSkill));
                }
                else
                    owner.GetAI().SendStateMessage(CharacterAI.CHARACTER_STATE.CS_SKILL, m_kData.nextSkill);
            }
            else
            {
                GraphicsUtil.ResetData();
            }
        }
        else if (m_bSkillIntrupted)
        {
            if (m_kData.nextSkill != 0)
            {
                owner.GetAI().SendStateMessage(CharacterAI.CHARACTER_STATE.CS_SKILL, m_kData.nextSkill);
            }
            else
            {
                GraphicsUtil.ResetData();
            }

            m_bSkillIntrupted = false;
        }

        // ����ͬʱ �����λ�ƣ����� �ȱ仯
        UpdateTranAndOrien(updateTime(delta));
    }

    
    public virtual void UpdateTranAndOrien(float updateTime)
    {
		// check skill move collision with enemy then stop it
		if ((owner.skill.getCurrentSkill().skill_id / 1000) == 201001)
		{
			// chongzhuang check dist with enemy
			if (Global.InArena())
			{
				Character target = owner.skill.getSkillTarget();

				if (target != null)
				{
					Vector3 hitPoint = PlayerPursueState.CalculatePursuePoint(owner, target);

					float dist = Vector3.Distance(owner.transform.position, hitPoint);

					if (hitPoint != Vector3.zero && dist < 0.4f)
					{
						// collisder with target
						m_bSkillIntrupted = true;
						Debug.Log("arena collider with enemy");
						return;
					}
				}
			}
			else
			{
				float fDistance = 0.0f;
				
				Character monster = MonsterManager.Instance.GetNearestMonster(out fDistance);
				Debug.Log("dist " + fDistance);
				if (monster != null && fDistance < 1.0f)
				{
					// collisder with target
					m_bSkillIntrupted = true;
					Debug.Log("collider with monster");
					return;
				}
			}
		}

        // ����ն ����ҡ�˶���
        if ((owner.skill.getCurrentSkill().skill_id / 1000) == 201003)
        {
            if (owner.getType() == CharacterType.CT_PLAYER)
            {
                Vector3 dir = owner.GetComponent<InputProperty>().m_kXuanFengZhanDir;

                if (dir != Vector3.zero)
                {
                    // ����ն��λ��
                    owner.movePosition(dir * updateTime * m_kSkillInfo.moveSpeed * m_nColliderStopValue);

                    // ͨ�����ͳ���ΪVector.x = 99999 ����ʾ������նר��
                    MessageManager.Instance.sendMessageAskMove(CharacterPlayer.character_property.getSeverID(), new Vector3(99999.0f, 0.0f, 0.0f), owner.getPosition());
                }
            }
            else if (owner.getType() == CharacterType.CT_PLAYEROTHER)
            {
                // �����˷�����ն ͨ��λ����Ϣ��ͬ��
                CharacterPlayerOther other = owner as CharacterPlayerOther;
                if (other.m_kXuanFengZhanPos.Count != 0)
                {
                    owner.transform.position = other.m_kXuanFengZhanPos[0];
                    other.m_kXuanFengZhanPos.RemoveAt(0);
                }
            }

            return;
        }

        if (Global.inMultiFightMap() && owner.skill.IsCurSkillCommon() && owner.getType() == CharacterType.CT_PLAYEROTHER)
        {
            CharacterPlayerOther other = owner as CharacterPlayerOther;
            if (other.m_kCommonAttackPos.Count != 0)
            {
                owner.transform.position = other.m_kCommonAttackPos[0];
                other.m_kCommonAttackPos.RemoveAt(0);
            }

            return;
        }

        if (Global.InWorldBossMap())
        {
            if (owner.skill.IsCurSkillCommon())
            {
                if (owner.getType() == CharacterType.CT_PLAYEROTHER)
                {
                    CharacterPlayerOther other = owner as CharacterPlayerOther;
                    if (other.m_kCommonAttackPos.Count != 0)
                    {
                        owner.transform.position = other.m_kCommonAttackPos[0];
                        other.m_kCommonAttackPos.RemoveAt(0);
                    }

                    return;
                }
                else if (owner.getType() == CharacterType.CT_MONSTER)
                {
                    // �����boss����Ҫλ��
                    return;
                }
            }
        }

        // λ�Ʊ任
        owner.movePosition(owner.getFaceDir() * updateTime * m_kSkillInfo.moveSpeed * m_nColliderStopValue);
        // ����任
    }

    public virtual void PlayerSpecialEffect()
    {
        if (m_kSkillInfo.SpecialEffect != "0")
        {
            EffectManager.Instance.createFX(m_kSkillInfo.SpecialEffect, owner.transform, m_kData.lastTick);
        }
    }

    public virtual void GenerateCollider()
    {
        if (m_kSkillInfo.skillRangePre != null)
        {
            MissleManager.Instance.createSkillArea("Model/prefab/" + m_kSkillInfo.skillRangePre,
            Vector3.zero, owner.transform, this, m_kData.lastTick, 1, 10000, 0.2f);
        }
    }

    public bool InCD()
    {
        if (m_kData.cool_down != 0)
        {
            return true;
        }
        return false;
    }

    public void setDir(Vector3 dir)
    {
        owner.setFaceDir(dir);
    }

    protected virtual int get_type_inner()
    {
        return skill_id;
    }
	
	protected virtual float get_repel_inner() {
        return m_kSkillInfo.atkRepel;
	}
	
	protected virtual float get_fly_inner() {
        return m_kSkillInfo.atkFly;
	}


    // ƽ���е��Զ�ս��AI
    //protected virtual void AIAutoFight(CharacterAI ai)
    //{
    //    CharacterMonster monster = null;
    //    MonsterManager.Instance.GetNearestMonster(out monster);
    //    if (monster)
    //    {
    //        // �й־ʹ��
    //        IdleState.AIBehaviour(ai, monster);
    //    }
    //}

    protected virtual bool CanEnterAutoAIByAttackState()
    {
        //CharacterMonster monster = null;
        //MonsterManager.Instance.GetNearestMonster(out monster);
        //if (monster)
        //{
        //    return IdleState.TryExecuteAI(owner.GetAI(), monster);
        //}

        Character character = getOwner().GetAI().GetNearestEnemy();
        if (character)
        {
            return AIUtil.TryExecuteAI(owner.GetAI(), character);
        }
        

        return false;
    }
}
