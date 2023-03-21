using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public PlayerCont player;

    Vector3 lastPos;
    float distToMove;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCont>(); //����� ������

        lastPos = player.transform.position; //��������� ��������� ������
        
    }

    // Update is called once per frame
    void Update()
    {
        distToMove = player.transform.position.x - lastPos.x;

        transform.position = new Vector3(transform.position.x + distToMove, transform.position.y, transform.position.z);  //����������� ������

        lastPos = player.transform.position;
    }
}
