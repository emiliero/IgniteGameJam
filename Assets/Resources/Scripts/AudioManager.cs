using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioClip deathSound;
    float timer;
    string[] blubs;
    AudioSource aS;

    void Awake()
    {
        aS = GetComponent<AudioSource>();
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        deathSound = (AudioClip)Resources.Load($"Audio/deadwav", typeof(AudioClip));
        timer = 0.33f;
        blubs = new string[10] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nince", "ten" };
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            PlayBlub();
            timer = (UnityEngine.Random.Range(0.00f, 0.99f));
        }
    }

    private void PlayBlub()
    {
        aS.PlayOneShot((AudioClip)Resources.Load($"Audio/" + blubs[UnityEngine.Random.Range(0,9)], typeof(AudioClip)));
    }

    public void DeathSound()
    {
        aS.PlayOneShot(deathSound);
    }
}
