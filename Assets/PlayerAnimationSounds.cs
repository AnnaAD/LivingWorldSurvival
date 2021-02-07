﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSounds : MonoBehaviour
{

	AudioSource animationSoundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        animationSoundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerFootstepSound() {
        animationSoundPlayer.pitch = Random.RandomRange(.8f, 1.2f);
    	animationSoundPlayer.Play();
    }
}
