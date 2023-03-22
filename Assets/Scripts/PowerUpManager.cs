using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private bool doublePoints;
    private bool safeMode;

    private bool powerusActive;

    private float powerupLengthCounter;

    private ScoreManager theScoreManager;
    private PlatGen thePlatGen;

    private float normalPointsPerSec;
    private float ballRate;

    private PlatDestoy[] ballList;

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlatGen = FindObjectOfType<PlatGen>();
    }

    // Update is called once per frame
    void Update()
    {
        if(powerusActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if(doublePoints)
            {
                theScoreManager.pointPerSec = normalPointsPerSec * 2;
            }

            if(safeMode)
            {
                thePlatGen.randomBallTheshold = 0;
            }


            if(powerupLengthCounter <= 0)
            {
                theScoreManager.pointPerSec = normalPointsPerSec;
                thePlatGen.randomBallTheshold = ballRate;

                powerusActive = false;
            }
        }
    }

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;        
        powerupLengthCounter = time;

        normalPointsPerSec = theScoreManager.pointPerSec;
        ballRate = thePlatGen.randomBallTheshold;

        if (safeMode)
        {
            ballList = FindObjectsOfType<PlatDestoy>();
            for (int i = 0; i < ballList.Length; i++)
            {
                if (ballList[i].gameObject.name.Contains("Ball"))
                {
                    ballList[i].gameObject.SetActive(false);
                }
            }

        }
        powerusActive = true;
    }

}
