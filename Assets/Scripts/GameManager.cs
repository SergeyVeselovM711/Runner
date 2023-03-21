using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform platGen;
    public Vector3 platStartPoint;

    public PlayerCont thePlayer;
    private Vector3 playerStartPoint;

    private PlatDestoy[] platList;


    private ScoreManager theScoreManager;

    public DeathMenu deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        platStartPoint = platGen.position; //возвращение персонажа
        playerStartPoint = thePlayer.transform.position; //переустановка платформ

        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        deathScreen.gameObject.SetActive(true);    

        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        deathScreen.gameObject.SetActive(false);

        platList = FindObjectsOfType<PlatDestoy>();
        for (int i = 0; i < platList.Length; i++)
        {
            platList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platGen.position = platStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;

    }

    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive (false);
        yield return new WaitForSeconds(0.5f); //ожидание перед перезапуском
        platList = FindObjectsOfType<PlatDestoy>();
        for (int i = 0; i < platList.Length; i++)
        {
            platList[i].gameObject.SetActive (false);    
        }
        thePlayer.transform.position = playerStartPoint;
        platGen.position = platStartPoint;
        thePlayer.gameObject.SetActive (true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    } */
}
