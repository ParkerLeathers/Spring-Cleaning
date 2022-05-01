using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hive : MonoBehaviour
{
    [SerializeField] private AudioSource fadeMusicSource;
    [SerializeField] private AudioSource victoryMusicSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(FadeAudioSource.StartFade(fadeMusicSource, 2, 0));
        victoryMusicSource.Play();
        SceneManager.LoadScene(2);
    }

}
