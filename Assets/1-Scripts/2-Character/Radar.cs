using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    
    public static Radar instance;
    [SerializeField] List<GameObject> enemys = new List<GameObject>();


    private void Awake()
    {
        instance = this;
    }
    public Transform GetNearestEnemy()
    {


        if (enemys.Count == 0) return null;


        Transform temp = enemys[0].transform;
        float dist = Mathf.Infinity;
        for (int i = 0; i < enemys.Count; i++)
        {
            if (dist >= Vector3.Distance(transform.position, enemys[i].transform.position))
            {
                temp = enemys[i].transform;
                dist = Vector3.Distance(transform.position, enemys[i].transform.position);
            }

        }

        return temp;

    }

    //Radara giren hedefli listeye ekle
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            enemys.Add(other.gameObject);

        }
    }

    private void Check()
    {

        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] == null)
            {
                enemys.RemoveAt(i);
            }
            else
            {
                if (enemys[i].GetComponent<EnemyModel>() && enemys[i].GetComponent<EnemyModel>().destroy) // Eğer düşman menzilden çıkmışsa listeden sil.
                {
                    enemys.RemoveAt(i);
                }
            }


        }

    }

    void Update()
    {
        Check();
    }

    // Radardan çıkan hedefi listeden sil
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < enemys.Count; i++)
        {

            if (other.gameObject.name == enemys[i].gameObject.name)
            {
                enemys.RemoveAt(i);
            }
        }
    }


    public void NextLevel()
    {
        enemys.Clear();
    }

}
