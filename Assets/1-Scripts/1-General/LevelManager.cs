using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    // Level Prefab'leri
    [SerializeField] private List<LevelModel> levels = new List<LevelModel>();
    [SerializeField] private GameObject currentLevel;
    //Level sayaç
    [SerializeField] private int levelCounter = 0; // levels listesindeki hangi level'da olduğumuzu söyler.

    private void Awake()
    {
        instance = this;
    }


    // Bulunan level'daki düşman sayısı. Düşmanlar Inspector'dan elle atılmalıdır.
    public int getNumOfEnemy() => levels[levelCounter].enemys.Count;

    public void NextLevel()
    {

        if (levelCounter + 1 == levels.Count) // Level Counter, liste boyutunu geçerse baştan başlat.
        {
            levelCounter = 0;
            Destroy(currentLevel);
            GameObject level = Instantiate(levels[levelCounter].gameObject, Vector3.zero, Quaternion.identity);
            currentLevel = level;
        }
        else
        {
            levelCounter++;
            Destroy(currentLevel);
            GameObject level = Instantiate(levels[levelCounter].gameObject, Vector3.zero, Quaternion.identity);
            currentLevel = level;
        }

        // Yeni level oluşturulduğunda Game Manager'a yeni düşman sayısını ata.
        GameManager.instance.setEnemyNumbers();
    }

    public void Restart()
    {
        Destroy(currentLevel);
        GameObject level = Instantiate(levels[levelCounter].gameObject, Vector3.zero, Quaternion.identity);
        currentLevel = level;

        // Yeni level oluşturulduğunda Game Manager'a yeni düşman sayısını ata.
        GameManager.instance.setEnemyNumbers();
    }


}
