using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{

    public Sprite sprite1;
    public Sprite sprite2;
    private SpriteRenderer sr;
    [SerializeField] private AudioSource hoverAudio;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseExit()
    {
        sr.sprite = sprite1;
    }

    private void OnMouseEnter()
    {
        sr.sprite = sprite2;
        hoverAudio.Play();
    }

    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene(1);
    }
}
