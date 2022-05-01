using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{

    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponentInParent<ParticleSystem>();
        ps.Emit(200);
        ps.Pause();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
