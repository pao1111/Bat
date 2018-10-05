using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


    public static SoundManager instance ;

    void Awake()
    {

        instance = this;

    }

    public AudioSource GunShot;

    public void PlaySound()
    {

        GunShot.Play();

    }

	
}
