using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QbbyController : MonoBehaviour
{
    public float upForce = 200f;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    AudioSource audioSource;
    public AudioClip flapSound;
    public AudioClip dieSound;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                PlaySound(flapSound);
            }
        }   
    }

    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Death");
        GameControl.instance.BirdDied();
        PlaySound(dieSound);
    }
    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);

    }
}
