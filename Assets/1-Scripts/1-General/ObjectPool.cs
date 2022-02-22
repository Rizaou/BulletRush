using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int numOfObjects = 100;
    [SerializeField] private List<IPoolItems> pool = new List<IPoolItems>();
    [SerializeField] private int objects = 0; // Inspector'den liste sayısını görmek için.
    [SerializeField] private GameObject obj;

    void Awake()
    {

        for (int i = 0; i < numOfObjects; i++)
        {
            GameObject temp = Instantiate(obj, Vector3.back * 50, Quaternion.identity);

            if (temp.GetComponent<IPoolItems>() != null)
            {
                IPoolItems item = temp.GetComponent<IPoolItems>();
            }
            

            pool.Add(temp.GetComponent<IPoolItems>());
        }
    }

    void Update()
    {
        objects = pool.Count;
    }
    public GameObject GetObject()
    {
        if (pool.Count == 0)
        {
            Debug.LogError("Obje Çekilemedi");
            
        }

        GameObject temp = pool[pool.Count -1].getGameObject();
        pool.RemoveAt(pool.Count-1);
        return temp;
    }

    public void GetAllObjects()
    {

    }

}
