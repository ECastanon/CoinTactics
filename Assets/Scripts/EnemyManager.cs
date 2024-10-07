using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    private PreBattleOptions preBattleOptions;
    private int counter;

    private void Start()
    {
        preBattleOptions = FindObjectOfType<PreBattleOptions>();
    }
    public void InformDeath() //If all enemies are defeated start next game
    {
        foreach (GameObject enemy in Enemies)
        {
            if (enemy.GetComponent<EnemyData>().isDefeated)
            {
                counter++;
            }
        }
        Debug.Log("Counter: " + counter);
        if(counter >= 4)
        {
            preBattleOptions.EnablePreBattleMenu();

            //Delete when enemy wave spawning is being worked on
            foreach (GameObject enemy in Enemies)
            {
                EnemyData ed = enemy.GetComponent<EnemyData>();
                ed.Hp = ed.maxHp;
                ed.UpdateHPBar();
                ed.isDefeated = false;
            }
        }

        counter = 0;
    }
}
