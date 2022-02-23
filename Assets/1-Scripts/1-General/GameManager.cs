using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager uIManager;
    public LevelManager levelManager;
    public GameObject player;
    public Radar radar;
    public float enemyNumberOnStart = 0; // Düşman sayısını ekranda göstermek için değişken
    public double ratio = 0; // Sahnede kalan düşman ile level başında bulunan düşman oranı. Slider için.

    void Awake()
    {

        instance = this;

    }
    void Start()
    {
        enemyNumberOnStart = levelManager.getNumOfEnemy();
    }



    public void EnemyDestroyed()
    {
        float enemyNum = levelManager.getNumOfEnemy();

        enemyNumberOnStart--;
        ratio = enemyNumberOnStart / enemyNum;

        if (enemyNumberOnStart == 0)
        {
            UIManager.instance.setSliderValue(1);
        }
        else
        {
            UIManager.instance.setSliderValue(1 - (float)ratio);
        }


    }

    public void Restart()
    {
        UIManager.instance.Restart();
        UIManager.instance.setSliderValue(0f);
        radar.NextLevel();
        UIManager.instance.Restart();
    }


    public void NextLevel()
    {
        Debug.Log("Yeni level");
        UIManager.instance.setSliderValue(0f);
        radar.NextLevel();

        UIManager.instance.ShowNextLevelUI();

    }

    public void setEnemyNumbers()
    {
        enemyNumberOnStart = levelManager.getNumOfEnemy();
    }

    public int EnemyOnStart()
    {
        return (int)enemyNumberOnStart;
    }

    public GameObject GetPlayer()
    {
        return instance.player;
    }


}
