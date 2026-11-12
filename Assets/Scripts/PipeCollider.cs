using System;
using UnityEngine;

public class PipeCollider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject gm;
    public AudioClip hitAudio;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().PlayOneShot(hitAudio); 
            Invoke("Death", 0.5f);
        }
    }

    private void Death()
    {
        gm.GetComponent<GameManager>().StopGame();
    }
}
