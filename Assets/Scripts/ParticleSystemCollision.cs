using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemCollision : MonoBehaviour
{

    private ParticleSystem ps;
    [SerializeField] private AudioSource puffOfAir;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponentInParent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        puffOfAir.Play();
        ps.Play();
        Destroy(this);
    }
}
