using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Level Prefab'leri
    [SerializeField] private List<LevelModel> levels = new List<LevelModel>();
    [SerializeField] private GameObject currentLevel;
    //Level sayaç
    [SerializeField] private int levelCounter = 0;

    public int getNumOfEnemy() => levels[levelCounter].enemys.Count;

    public void NextLevel()
    {
        if(levelCounter +1 == levels.Count)
        {
            levelCounter = 0;
            Destroy(currentLevel);
            GameObject level = Instantiate(levels[levelCounter].gameObject,Vector3.zero,Quaternion.identity);
            currentLevel = level;
        }
        else
        {
            levelCounter++;
            Destroy(currentLevel);
            GameObject level = Instantiate(levels[levelCounter].gameObject,Vector3.zero,Quaternion.identity);
            currentLevel = level;
        }
    }

    public void Restart()
    {
        
    }


}
