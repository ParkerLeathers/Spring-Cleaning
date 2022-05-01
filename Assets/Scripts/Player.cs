using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private AudioSource flowerSound;
    private AudioSource flowerSound2;
    private AudioSource flowerSound3;
    private float rotation;
    Tilemap tilemap;
    private bool[,] hasFlower;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rotation = rb.rotation;
        flowerSound = GameObject.Find("FlowerSound").GetComponent<AudioSource>();
        flowerSound2 = GameObject.Find("FlowerSound2").GetComponent<AudioSource>();
        flowerSound3 = GameObject.Find("FlowerSound3").GetComponent<AudioSource>();
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        hasFlower = new bool[tilemap.size.x * 2,tilemap.size.y * 2];
    }

    // Update is called once per frame
    void Update()
    {
        //--Movement--
        
        Vector2 vec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (vec.magnitude > 1)
            vec.Normalize();
        if (vec.x != 0 || vec.y != 0)
        {
            float deltaAng = Vector2.SignedAngle(new Vector2(Mathf.Cos(rotation * Mathf.Deg2Rad), Mathf.Sin(rotation * Mathf.Deg2Rad)), new Vector2(vec.x, vec.y));
            float move = rotationSpeed;

            if (Mathf.Abs(deltaAng) < move)
                move = Mathf.Abs(deltaAng);

            if (deltaAng < 0)
                move *= -1;

            rotation += move;

            if (Mathf.Abs(rotation) > 95)
                 sr.flipX = true;
            else if(Mathf.Abs(rotation) < 85)
                 sr.flipX = false;

            if (rotation > 180)
                rotation -= 360;
            else if (rotation < -180)
                rotation += 360;

            if(!sr.flipX)
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
            else if (rotation>1)
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180 + rotation));
            else if(rotation<-1)
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 + rotation));
        }
        rb.velocity = vec * speed;


        //--Flower Growth--

        Vector3Int pos;

        //left tile
        pos = tilemap.WorldToCell(new Vector3(transform.position.x - tilemap.cellSize.x, transform.position.y, 0));
        if (!hasFlower[pos.x + tilemap.size.x, pos.y + tilemap.size.y] && tilemap.GetTile(pos))
        {
            flowerSound.pitch = Random.Range(0.7f, 1.4f);
            flowerSound.Play();
            flowerSound2.pitch = Random.Range(0.7f, 1.4f);
            flowerSound2.Play();
            flowerSound3.pitch = Random.Range(0.7f, 1.4f);
            flowerSound3.Play();
            generateFlower(pos);
            hasFlower[pos.x + tilemap.size.x, pos.y + tilemap.size.y] = true;
        }

        //right tile
        pos = tilemap.WorldToCell(new Vector3(transform.position.x + tilemap.cellSize.x, transform.position.y, 0));
        if (!hasFlower[pos.x + tilemap.size.x, pos.y + tilemap.size.y] && tilemap.GetTile(pos))
        {
            flowerSound.pitch = Random.Range(0.7f, 1.4f);
            flowerSound.Play();
            flowerSound2.pitch = Random.Range(0.7f, 1.4f);
            flowerSound2.Play();
            flowerSound3.pitch = Random.Range(0.7f, 1.4f);
            flowerSound3.Play();
            generateFlower(pos);
            hasFlower[pos.x + tilemap.size.x, pos.y + tilemap.size.y] = true;
        }

        //down tile
        pos = tilemap.WorldToCell(new Vector3(transform.position.x, transform.position.y - tilemap.cellSize.y, 0));
        if (!hasFlower[pos.x + tilemap.size.x, pos.y + tilemap.size.y] && tilemap.GetTile(pos))
        {
            flowerSound.pitch = Random.Range(0.7f, 1.4f);
            flowerSound.Play();
            flowerSound2.pitch = Random.Range(0.7f, 1.4f);
            flowerSound2.Play();
            flowerSound3.pitch = Random.Range(0.7f, 1.4f);
            flowerSound3.Play();
            generateFlower(pos);
            hasFlower[pos.x + tilemap.size.x, pos.y + tilemap.size.y] = true;
        }

        //up tile
        pos = tilemap.WorldToCell(new Vector3(transform.position.x, transform.position.y + tilemap.cellSize.y, 0));
        if(!hasFlower[pos.x + tilemap.size.x, pos.y + tilemap.size.y] && tilemap.GetTile(pos))
        {
            flowerSound.pitch = Random.Range(0.7f, 1.4f);
            flowerSound.Play();
            flowerSound2.pitch = Random.Range(0.7f, 1.4f);
            flowerSound2.Play();
            flowerSound3.pitch = Random.Range(0.7f, 1.4f);
            flowerSound3.Play();
            generateFlower(pos);
            hasFlower[pos.x + tilemap.size.x, pos.y + tilemap.size.y] = true;
        }
    }

    void generateFlower(Vector3Int pos)
    {
        Instantiate(GameObject.Find("Green"), new Vector3(tilemap.CellToWorld(pos).x + Random.Range(0,tilemap.cellSize.x), tilemap.CellToWorld(pos).y + Random.Range(0, tilemap.cellSize.y)), Quaternion.identity);
        Instantiate(GameObject.Find("Red"), new Vector3(tilemap.CellToWorld(pos).x + Random.Range(0, tilemap.cellSize.x), tilemap.CellToWorld(pos).y + Random.Range(0, tilemap.cellSize.y)), Quaternion.identity);
        Instantiate(GameObject.Find("Blue"), new Vector3(tilemap.CellToWorld(pos).x + Random.Range(0, tilemap.cellSize.x), tilemap.CellToWorld(pos).y + Random.Range(0, tilemap.cellSize.y)), Quaternion.identity);
    }
}
