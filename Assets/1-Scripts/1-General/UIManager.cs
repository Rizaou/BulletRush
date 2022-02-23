using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{




    public static UIManager instance;
    [SerializeField] private Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI textMesh;
    [SerializeField] private GameObject levelUI;
    [SerializeField] private GameObject restartUI;
    [SerializeField] private GameObject nextUI;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        textMesh.text = GameManager.instance.EnemyOnStart().ToString();
    }

    public Slider getSlider { get { return slider; } }
    public void setSliderValue(float value)
    {

        // Slider değerini value yap.
        //Eğer 1'e eşitse sonraki Level'a geç


        slider.value = value;
        if (value >= 1)
        {
            GameManager.instance.NextLevel();
            slider.value = 0;
        }

    }

    public void Restart()
    {
        // Normal UI kapat
        // Restart UI göster
        // Oyunu dondur

        levelUI.SetActive(false);
        restartUI.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartButton()
    {
        LevelManager.instance.Restart();
        ShowLevelUI();
    }

    public void ShowLevelUI()
    {
        // Normal UI göster

        levelUI.SetActive(true);
        nextUI.SetActive(false);
        restartUI.SetActive(false);
        Time.timeScale = 1;
    }
    public void ShowNextLevelUI()
    {

        // Normal UI kapat
        // Next Level UI göster
        // Oyunu dondur.

        levelUI.SetActive(false);
        nextUI.SetActive(true);

        Time.timeScale = 0;
    }

    public void NewLevelButton()
    {

        LevelManager.instance.NextLevel();
        ShowLevelUI();

    }
}
