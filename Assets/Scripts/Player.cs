using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    public float force;
    private bool timeBetween = true;
    private Animator anim;
    public AudioClip aleteo;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("jumpAgain", 0, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = new Vector2(0, 1);
        
        if (Input.GetKeyDown(KeyCode.Space) && timeBetween)
        {
            rb.linearVelocityY = 0;
            rb.AddForce(dir * force);
            timeBetween = false;
            anim.SetBool("Inclinar", true);
            GetComponent<AudioSource>().PlayOneShot(aleteo);
            
        }
        
    }

    private void jumpAgain()
    {
        anim.SetBool("Inclinar", false);

        timeBetween = true;
    }
}
