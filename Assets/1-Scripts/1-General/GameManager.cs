using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uIManager;
    [SerializeField] LevelManager levelManager;
    [SerializeField] Radar radar;
    [SerializeField] float enemyNumberOnStart = 0;
    [SerializeField] double ratio = 0;

    void Start()
    {
        enemyNumberOnStart = levelManager.getNumOfEnemy();
    }
    private void Update()
    {


    }


    public void EnemyDestroyed()
    {
        float enemyNum = levelManager.getNumOfEnemy();

        enemyNumberOnStart--;

        Debug.Log("enemy num " + enemyNum + " enemyNumberInStart" + enemyNumberOnStart );
        ratio = enemyNumberOnStart / enemyNum;

        if (enemyNumberOnStart == 0)
        {
            uIManager.setSliderValue(1);
        }
        else
        {
            uIManager.setSliderValue(1 - (float)ratio);
        }


    }


    public void NextLevel()
    {
        Debug.Log("Yeni level");
        radar.NextLevel();
        levelManager.NextLevel();
        enemyNumberOnStart = levelManager.getNumOfEnemy();
    }


    public int EnemyOnStart()
    {
        return (int)enemyNumberOnStart;
    }
}
