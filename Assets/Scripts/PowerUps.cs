using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool doublePoints;
    public bool safeMode;

    public float powerupLength;

    private PowerUpManager thePowerUpManager;

    public Sprite[] powerupSprites;
    
    // Start is called before the first frame update
    void Start()
    {
        thePowerUpManager = FindObjectOfType<PowerUpManager>();
    }

    void Awake()
    {
        int powerupSelector = Random.Range(0,2);

        switch (powerupSelector)
        {
            case 0: doublePoints = true;
                break;

            case 1: safeMode = true; 
                break;
        }

        GetComponent<SpriteRenderer>().sprite = powerupSprites[powerupSelector];

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            thePowerUpManager.ActivatePowerup(doublePoints, safeMode, powerupLength);
        }

        gameObject.SetActive(false);

    }

}
