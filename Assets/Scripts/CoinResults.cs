using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinResults : MonoBehaviour
{
    [HideInInspector] public int outcome;

    public int characterSlot;
    public List<GameObject> allSkills = new List<GameObject>();

    [Header("Skill Assignments")]
    public Attack assignedSkill_0;
    public Attack assignedSkill_1;
    public Attack assignedSkill_2;
    public Attack assignedSkill_3;
    public Attack assignedSkill_4;

    public void PlayCoinResult()
    {
        switch (outcome)
        {
            case 0:
                assignedSkill_0.ActivateSkill(characterSlot);
                Debug.Log(gameObject.name + " uses " + assignedSkill_0 + "!!!");
                break;
            case 1:
                assignedSkill_1.ActivateSkill(characterSlot);
                Debug.Log(gameObject.name + " uses " + assignedSkill_1 + "!!!");
                break;
            case 2:
                assignedSkill_2.ActivateSkill(characterSlot);
                Debug.Log(gameObject.name + " uses " + assignedSkill_2 + "!!!");
                break;
            case 3:
                assignedSkill_3.ActivateSkill(characterSlot);
                Debug.Log(gameObject.name + " uses " + assignedSkill_3 + "!!!");
                break;
            case 4:
                assignedSkill_4.ActivateSkill(characterSlot);
                Debug.Log(gameObject.name + " uses " + assignedSkill_4 + "!!!");
                break;
            default:
                Debug.Log("INVALID COIN RESULT: " + outcome);
                break;
        }
    }
}
