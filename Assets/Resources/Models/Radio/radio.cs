using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio : MonoBehaviour
{
    Animator anim;
    public AudioClip press_audio_clip, music_clip;
    AudioSource aSource, mSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
        mSource = this.gameObject.AddComponent<AudioSource>();
        mSource.clip = music_clip;
        mSource.loop = true;
    }

    void Update()
    {
      
    }

    public void Use()
    {
        if (!anim.GetBool("isON"))
        {
            anim.SetBool("isON", true);
            mSource.clip = music_clip;
            mSource.Play();
        }
        else
        {
            anim.SetBool("isON", false);
            mSource.Stop();
        }
        aSource.clip = press_audio_clip;
        aSource.Play();
    }
}