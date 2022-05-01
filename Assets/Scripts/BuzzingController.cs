using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzingController : MonoBehaviour
{
    [SerializeField] private AudioSource buzzing;
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            buzzing.Play();
        }
        
        if(Input.GetKeyUp(KeyCode.W))
        {
            buzzing.Stop();
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            buzzing.Play();
        }
        
        if(Input.GetKeyUp(KeyCode.A))
        {
            buzzing.Stop();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            buzzing.Play();
        }
        
        if(Input.GetKeyUp(KeyCode.S))
        {
            buzzing.Stop();
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            buzzing.Play();
        }
        
        if(Input.GetKeyUp(KeyCode.D))
        {
            buzzing.Stop();
        }
    }
}