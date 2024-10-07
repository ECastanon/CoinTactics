using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPlacement : MonoBehaviour
{
    public GameObject selectedCharacter;

    [Header("CharacterSkills")]
    public GameObject Heads_0;
    public GameObject Heads_1;
    public GameObject Heads_2;
    public GameObject Heads_3;
    public GameObject Heads_4;

    public void AddSelectedCharacterData(GameObject chara)
    {
        CoinResults cr = chara.GetComponent<CoinResults>();
        selectedCharacter = chara;

        Heads_0 = cr.assignedSkill_0.gameObject;
        Heads_1 = cr.assignedSkill_1.gameObject;
        Heads_2 = cr.assignedSkill_2.gameObject;
        Heads_3 = cr.assignedSkill_3.gameObject;
        Heads_4 = cr.assignedSkill_4.gameObject;
    }
}
