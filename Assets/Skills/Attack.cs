using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.GraphicsBuffer;

public class Attack : MonoBehaviour
{
    public string SkillName;
    public List<EnemyData> enemyDatas = new List<EnemyData>();
    public GameObject targetedEnemy;
    public Transform Player;
    public bool moving;
    public float timer;
    public float slot;

    public float damage;

    private void Start()
    {
        Player = transform.parent.parent;
    }

    public void ActivateSkill(int slot)
    {
        this.slot = slot;
        GetEnemies();
        targetedEnemy = enemyDatas[SelectTarget()].gameObject;

        //Currently Broken
        //StartCoroutine(MoveToTarget());

        targetedEnemy.GetComponent<EnemyData>().Hp -= damage;
        targetedEnemy.GetComponent<EnemyData>().UpdateHPBar();
    }

    private int SelectTarget()
    {
        int target = 1;
        switch (slot)
        {
            case 1:
                target = 0;
                if (enemyDatas[target].isDefeated)
                {
                    target = 3;
                    if (enemyDatas[target].isDefeated)
                    {
                        target = 1;
                        if (enemyDatas[target].isDefeated)
                        {
                            target = 2;
                        }
                    }
                }
                break;
            case 2:
                target = 2;
                if (enemyDatas[target].isDefeated)
                {
                    target = 0;
                    if (enemyDatas[target].isDefeated)
                    {
                        target = 3;
                        if (enemyDatas[target].isDefeated)
                        {
                            target = 1;
                        }
                    }
                }
                break;
            case 3:
                target = 1;
                if (enemyDatas[target].isDefeated)
                {
                    target = 0;
                    if (enemyDatas[target].isDefeated)
                    {
                        target = 3;
                        if (enemyDatas[target].isDefeated)
                        {
                            target = 2;
                        }
                    }
                }
                break;
            case 4:
                target = 0;
                if (enemyDatas[target].isDefeated)
                {
                    target = 3;
                    if (enemyDatas[target].isDefeated)
                    {
                        target = 1;
                        if (enemyDatas[target].isDefeated)
                        {
                            target = 2;
                        }
                    }
                }
                break;
            default:
                Debug.Log("INVALID SLOT: " + slot);
                break;
        }
        return target;
    }

    private void GetEnemies()
    {
        enemyDatas.Clear();
        foreach (Transform enemy in GameObject.Find("Enemies").transform)
        {
            enemyDatas.Add(enemy.gameObject.GetComponent<EnemyData>());
        }
    }
    private IEnumerator MoveToTarget()
    {
        Debug.Log("MOVETOTARGET");
        moving = true;

        float distance = Vector3.Distance(Player.position, enemyDatas[SelectTarget()].transform.position);
        yield return new WaitUntil(() => distance <= .1f);

        moving = false;
    }
    
    private void Update()
    {
        if (moving)
        {
            Player.position = Vector2.MoveTowards(Player.position, enemyDatas[SelectTarget()].transform.position, Time.deltaTime);
        }
    }
}
