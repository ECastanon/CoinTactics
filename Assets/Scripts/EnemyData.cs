using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyData : MonoBehaviour
{
    public EnemyManager enemyManager;
    public bool isDefeated;
    public float Hp, maxHp;
    public Image hpBar;

    private void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();

        Hp = maxHp;
    }

    public void UpdateHPBar()
    {
        hpBar.fillAmount = Hp / maxHp;
        if (Hp <= 0)
        {
            isDefeated = true;
            GetComponent<SpriteRenderer>().color = new Color(1, .42f, .42f, .5f);

            //Informs the Manager the current State
            enemyManager.InformDeath();
        }
        //Delete when enemy wave spawning is being worked on
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, .42f, .42f, 1f);

        }
    }
}
