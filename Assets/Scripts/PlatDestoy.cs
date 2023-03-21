using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatDestoy : MonoBehaviour
{
    public GameObject destroyPoint;


    // Start is called before the first frame update
    void Start()
    {
        destroyPoint = GameObject.Find("DestroyP"); //поиск подходящего объекта
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destroyPoint.transform.position.x) //уничтожение
        {
            //    Destroy(gameObject);

            gameObject.SetActive(false);
        }
    }
}
