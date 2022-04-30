using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicIntro;
    [SerializeField] private AudioSource musicLoop;
    // Start is called before the first frame update
    void Start()
    {
        musicIntro.Play();
        musicLoop.PlayDelayed(musicIntro.clip.length);
    }
}