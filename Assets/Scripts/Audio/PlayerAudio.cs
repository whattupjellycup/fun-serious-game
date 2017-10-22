﻿using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour
{
    public bool onPath = false;
    public bool onGrass = false;
    public bool onBuildingFloor = false;

    private float stepTimer = 0f;
    private float stepPause = 0.2f; // amount of time between steps

    private float xpos = 0f;
    private float ypos = 0f;

    private PlayerController playerController;
    private TouchControls touchControls;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        touchControls = GetComponent<TouchControls>();
        audioSource = GetComponent<AudioSource>();

        onPath = false;
    }

    // Update is called once per frame
    void Update()
    {
        Step();
        TrackPosition();

    }

    void TrackPosition()
    {
        xpos = transform.position.x;
        ypos = transform.position.y;
    }
    void Step()
    {
        
        if (xpos != transform.position.x || ypos != transform.position.y)
        {
            Debug.Log("STEP");
            if (onBuildingFloor)
            {
                StepSound(SoundManager.audioBuildingStep, SoundManager.NUMBER_OF_BUILDING_STEPS);
            }
            else if (onPath)
            {
                StepSound(SoundManager.audioPathStep, SoundManager.NUMBER_OF_PATH_STEPS);
            }
            else if (onGrass)
            {
                StepSound(SoundManager.audioDirtStep, SoundManager.NUMBER_OF_GRASS_STEPS);
            }
            
        }
        if (stepTimer > 0f)
        {
            stepTimer -= Time.deltaTime;

        }
        if (stepTimer < 0f)
        {
            stepTimer = 0f;
        }

    }
    void StepSound(AudioClip[] audioClip, int numberOfSoundVariations)
    {
        Debug.Log("Play sound");
        if (stepTimer == 0)
        {
            audioSource.PlayOneShot(audioClip[Random.Range(0, numberOfSoundVariations)], 0.2f);
            stepTimer = stepPause;
        }
    }
}
