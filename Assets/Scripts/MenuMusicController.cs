using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicLoop;
    // Start is called before the first frame update
    void Start()
    {
        musicLoop.Play();
    }
}