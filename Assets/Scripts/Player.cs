using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        print(rb.velocity);
        
        Vector2 vec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (vec.magnitude > 1)
            vec.Normalize();
        if (vec.x != 0 || vec.y != 0)
        {
            float deltaAng = Vector2.SignedAngle(new Vector2(Mathf.Cos(rb.rotation * Mathf.Deg2Rad), Mathf.Sin(rb.rotation * Mathf.Deg2Rad)), new Vector2(vec.x, vec.y));
            print(deltaAng);
            rb.MoveRotation(90);
            float move = 1;

            if (Mathf.Abs(deltaAng) < move) {
                move = Mathf.Abs(deltaAng);
            }
            if (deltaAng < 0) {
                move *= -1;
            }

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rb.rotation + move));
        }
        rb.velocity = vec * speed;

    }
}
