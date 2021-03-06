using UnityEngine;
using System.Collections;

public class PlayerAnimCallback : MonoBehaviour {
    //MonoBehaviour {
	
	CharacterPlayer player;
	
	// Use this for initialization
	void Start () {
		player = GetComponent<CharacterPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void playWeaponSound() {
		if (!player) return;
		Weapon w = player.GetComponentInChildren<Weapon>();
		if (!w) return;
		w.playWeaponSound();
	}
	
	public void playEffect(GameObject eff) 
    {
		if (eff && player) 
		{
            if (!CharacterAI.IsInState(player, CharacterAI.CHARACTER_STATE.CS_DIE))
            {
                // 防止死了还能放特效
                //if (EffectManager.Instance.m_kPreLoadedRes.ContainsKey(eff.name))
                //{
                //    GameObject fxEff = BundleMemManager.Instance.instantiateObj(EffectManager.Instance.m_kPreLoadedRes[eff.name],Vector3.zero, Quaternion.identity);
                //    fxEff.transform.parent = player.transform;
                //    fxEff.transform.localPosition = Vector3.zero;
                //    fxEff.transform.localRotation = Quaternion.identity;
                //    Destroy(fxEff, 10.0f);
                //}
                //else
                    EffectManager.Instance.createFX(eff, player.transform, 10.0f);
            }
		}
	}
	
	public void playEffectWorldCoord(GameObject eff) {
		if (eff && player) {
            EffectManager.Instance.createFX(eff, player.transform.position, player.transform.rotation, 2.0f);
		}
	}
	
	public void showWeaponTrail() {
		if (!player) return;
		player.showWeaponTrail();
	}
	
	public void hideWeaponTrail() {
		if (!player) return;
		player.hideWeaponTrail();
	}
	
	public void shakeCameraSmallPlayerFront(float time) {

        EffectManager.Instance.createCameraShake(0, 0.1f, time);
	}
	
	public void shakeCameraBigPlayerFront(float time) {

        EffectManager.Instance.createCameraShake(0, 0.6f, time);
	}
	
	public void shakeCameraSmallUpDown(float time) {

        EffectManager.Instance.createCameraShake(1, 0.1f, time);
	}
	
	public void shakeCameraBigUpDown(float time) {

        EffectManager.Instance.createCameraShake(1, 0.6f, time);
	}
	
	public void shakeCameraSmall(float time) {

        EffectManager.Instance.createCameraShake(2, 0.1f, time);
	}
	
	public void shakeCameraBig(float time) {

        EffectManager.Instance.createCameraShake(2, 0.6f, time);
	}
	
	public void createAddAttack() {

        if (player == null)
        {
            return;
        }
        
		
        //if (player.skill.addAttackEff == null) {
        //    player.skill.addAttackEff = EffectManager.sEffectManager.createFX("Effect/Effect_Prefab/Role/Skill/zhanyishalu", player.transform, 10000);
        //}

        player.AddBuff(1);
	}
	
	public void createAddDefend() {

        if (player == null)
        {
            return;
        }
		
        //if (player.skill.addDefendEff == null) {
        //    player.skill.addDefendEff = EffectManager.sEffectManager.createFX("Effect/Effect_Prefab/Role/Skill/yongqihudun", player.transform, 10000);
        //}

        player.AddBuff(2);
	}
	
	public void playAudio( AudioClip clip ) {
		
		if (audio && clip) {
			audio.PlayOneShot(clip);
		}
	}

    public void clearMonsterFightDirty() 
    {
        CharacterAnimCallback.ClearFightDirty(player);
	}

    public void GeneradeCollider()
    {
        if (!player)
            return;

        SkillAppear skillCmd = player.skill.getCurrentSkill();
        if (skillCmd != null && skillCmd.m_kSkillInfo.skillRangePre != null)
        {
            if (player.skill.getCurrentSkill().m_kSkillInfo.SpecialEffectLoop == 1)
            {
                if (player.skill.getCurrentSkill().m_bDurationalSkillFirstColliderFlag)
                {
                    MissleManager.Instance.CreateSkillCollider("Model/prefab/" + skillCmd.m_kSkillInfo.skillRangePre, Vector3.zero, player, skillCmd);
                    player.skill.getCurrentSkill().m_bDurationalSkillFirstColliderFlag = false;
                }
            }
            else
                MissleManager.Instance.CreateSkillCollider("Model/prefab/" + skillCmd.m_kSkillInfo.skillRangePre, Vector3.zero, player, skillCmd);
        }
    }

    public void RangeDamageHurt()
    {
        if (!player)
            return;

        SkillAppear kCurSkill = player.skill.getCurrentSkill();
        if (kCurSkill != null)
        {
            // draw lines
            DrawRangeLines(kCurSkill.m_kSkillInfo.skillAngle, kCurSkill.m_kSkillInfo.skillRadius);
            BattleManager.Instance.RangeSkillDamageCal(kCurSkill);
        }
    }

    void DrawRangeLines(int nDegree, float radius)
    {
        Vector3 vecFaceDir = CharacterPlayer.sPlayerMe.getFaceDir();
        vecFaceDir.Normalize();

        

        Quaternion rotL = Quaternion.Euler(0, -nDegree * 0.5f, 0);
        GraphicsUtil.m_vecLineStart = CharacterPlayer.sPlayerMe.getPosition() +
            rotL * vecFaceDir * radius;

        GraphicsUtil.m_vecLineStart += new Vector3(0.0f, 0.1f, 0.0f);

        Quaternion rotR = Quaternion.Euler(0, nDegree * 0.5f, 0);
        GraphicsUtil.m_vecLineEnd = CharacterPlayer.sPlayerMe.getPosition() +
            rotR * vecFaceDir * radius;

        GraphicsUtil.m_vecLineEnd += new Vector3(0.0f, 0.1f, 0.0f);

        GraphicsUtil.m_vecOriginal = CharacterPlayer.sPlayerMe.getPosition();

    }
}
