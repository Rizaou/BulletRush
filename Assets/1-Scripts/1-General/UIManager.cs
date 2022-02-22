using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
   
    [SerializeField] private Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI textMesh;
    [SerializeField] private float sliderValue = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       sliderValue = slider.value;
       textMesh.text = gameManager.EnemyOnStart().ToString();
    }

    public Slider getSlider { get { return slider; } }
    public void setSliderValue(float value)
    {
        slider.value = value;
        if(value >= 1)
        {
            gameManager.NextLevel();
            slider.value = 0;
        }

    }
}
