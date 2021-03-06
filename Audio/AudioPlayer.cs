﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {


    public static AudioPlayer Instance;

    void Awake()
    {
        Instance = this;


        clipManager = new ClipsManager();

        sourceManager = new AudioSourceManager(gameObject);

    }


    ClipsManager clipManager;

    AudioSourceManager sourceManager;


    public void Play(string audioName)
    {


       AudioSource  tmpSource=   sourceManager.GetFreeAudioSource();


        SingleClip  tmpClip= clipManager.GetClips(audioName);


        if (tmpClip != null)
        {
            tmpClip.Play(tmpSource);
        }
        else
        {

            Debug.LogError("  you play  audio  is not  exit");
        }
       
          
          
    }

    public void Stop(string audioName)
    {


        sourceManager.StopPlayingAudio(audioName);

    }

	// Use this for initialization
	void Start () {
		
	}
	

   
	// Update is called once per frame
	void Update () {
		
	}
}
