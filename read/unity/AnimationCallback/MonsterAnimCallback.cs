using UnityEngine;
using System.Collections;
using manager;

public class MonsterAnimCallback : MonoBehaviour 
{	
	CharacterMonster monster;
	
	// Use this for initialization
	void Start () 
    {
		monster = GetComponent<CharacterMonster>();
	}
	
	public void shoot(GameObject skillPrefab) 
    {
        // 不是主机 并且 是怪物发出的 而且是在多人副本的时候是无效的
        //if (!CharacterPlayer.character_property.getHostComputer() && Global.inMultiFightMap())
        //{
        //    return;
        //}

		Vector3 tmp = CharacterPlayer.sPlayerMe.transform.position - monster.transform.position;
        tmp.Normalize();

        MissleManager.Instance.createMissle(
			skillPrefab,
			monster.transform.position + new Vector3(0,0.5f,0),
			tmp,
			6.0f,
			10,
			monster);
	}
	
	public void chop(GameObject skillPrefab) 
    {
        // 不是主机 并且 是怪物发出的 而且是在多人副本的时候是无效的
        if (!CharacterPlayer.character_property.getHostComputer() && Global.inMultiFightMap())
        {
            return;
        }

        MissleManager.Instance.createSkillArea(skillPrefab, Vector3.zero, monster.getTagPoint("attack"),
            monster.skill.GetCommonAttack(), 0.2f, 0);
	}
	


	public void playEffect(GameObject eff) 
    {
		if (eff && monster) 
        {
            EffectManager.Instance.createFX(eff, monster.transform, 10.0f);
		}
	}

    public void playEffectOnLeftHand(GameObject eff)
    {
        if (!eff)
        {
            return;
        }

        if (monster)
        {
            EffectManager.Instance.createFX(eff, monster.getTagPoint("left_hand"), 2.0f);
        }
        else
        {
            Transform tran = transform.FindChild("Bip01/Bip01 Pelvis/Bip01 Spine/Bip01 Spine1/Bip01 Neck/Bip01 L Clavicle/Bip01 L UpperArm/Bip01 L Forearm/Bip01 L Hand/left_hand");
            EffectManager.Instance.createFX(eff, tran, 2.5f);
        }
    }
	
	public void playEffectWorldCoord(GameObject eff) 
    {
		if (eff && monster) 
        {
            EffectManager.Instance.createFX(eff, monster.transform.position, monster.transform.rotation, 10.0f);
		}
	}
	
	public void playAudio( AudioClip clip ) 
    {
        AudioManager.Instance.PlayAudio(this.gameObject, clip);
	}

    

    public virtual void GeneradeCollider()
    {
        if (!monster)
            return;

        // 不是主机 并且 是怪物发出的 而且是在多人副本的时候是无效的
        if (!CharacterPlayer.character_property.getHostComputer() && Global.inMultiFightMap())
        {
            return;
        }

        CharacterAnimCallback.ClearFightDirty(monster);

        //SkillAppear skillCmd = monster.skill.getCurrentSkill();
        //if (skillCmd != null)
        //{
        //    MissleManager.Instance.createSkillArea("Model/prefab/" + skillCmd.m_kSkillInfo.skillRangePre,
        //        Vector3.zero, monster.transform, skillCmd, 0.1f, 0);
        //}
        

        SkillAppear skillCmd = monster.skill.getCurrentSkill();
        if (skillCmd != null && skillCmd.m_kSkillInfo.skillRangePre != null)
        {
            if (monster.skill.getCurrentSkill().m_kSkillInfo.SpecialEffectLoop == 1)
            {
                if (monster.skill.getCurrentSkill().m_bDurationalSkillFirstColliderFlag)
                {
                    MissleManager.Instance.CreateSkillCollider("Model/prefab/" + skillCmd.m_kSkillInfo.skillRangePre, Vector3.zero, monster, skillCmd);
                    monster.skill.getCurrentSkill().m_bDurationalSkillFirstColliderFlag = false;
                }
            }
            else
                MissleManager.Instance.CreateSkillCollider("Model/prefab/" + skillCmd.m_kSkillInfo.skillRangePre, Vector3.zero, monster, skillCmd);
        }
    }
}
