using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip shipDeath, playerFire, bombFire;
    private static AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        shipDeath = Resources.Load<AudioClip>("ShipDeath");
        playerFire = Resources.Load<AudioClip>("PlayerFire");
        bombFire = Resources.Load<AudioClip>("BombFire");

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "shipDeath":
                source.PlayOneShot(shipDeath);
                break;
            case "playerFire":
                source.PlayOneShot(playerFire);
                break;
            case "bombFire":
                source.PlayOneShot(bombFire);
                break;
        }
    }
}
