using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzingController : MonoBehaviour
{
    [SerializeField] private AudioSource buzzing;
    // Start is called before the first frame update
    private void Start()
    {
        buzzing.Play();
    }

    void LateUpdate()
    {
        buzzing.volume = GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude / GameObject.Find("Player").GetComponent<Player>().speed * .33f;
    }
}