﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource player_source;
    AudioClip intro_clip;
    AudioClip eerie_clip;
    AudioClip monsterIntro_clip;
    AudioClip scream_clip; 

    private void Awake()
    {
        player_source = GameObject.FindWithTag("Player").GetComponent<AudioSource>(); 

        intro_clip = Resources.Load<AudioClip>("Intro Door MP3");
        eerie_clip = Resources.Load<AudioClip>("Eerie MP3");
        monsterIntro_clip = Resources.Load<AudioClip>("Spawn Moan MP3");
        scream_clip = Resources.Load<AudioClip>("Scream"); 
    }

    private void Start()
    {
        //player_source.PlayOneShot(intro_clip); 
    }

    public void MonsterSpawnClip()
    {
        player_source.PlayOneShot(monsterIntro_clip);
    }

    public void JumpScareScream()
    {
        player_source.PlayOneShot(scream_clip); 
    }

    public void Eerie()
    {
        player_source.PlayOneShot(intro_clip);
    }
}