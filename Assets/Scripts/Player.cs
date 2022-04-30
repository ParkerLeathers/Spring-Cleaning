using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (vec.magnitude > 1)
            vec.Normalize();

        if (vec.x != 0 || vec.y != 0)
            Quaternion.RotateTowards(transform.rotation, new Quaternion(vec.x,vec.y,0,0), Time.deltaTime);
         rb.velocity = vec * Time.deltaTime * speed;
    }
}
