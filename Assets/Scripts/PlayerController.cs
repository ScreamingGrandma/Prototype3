using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 2000f;
    public float gravityModifier;

    public bool isOnGround = true;

    public bool gameOver = false;

    private Animator playerAnim;

    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;

    public AudioClip crashSound;
    public AudioClip jumpSound;

    public AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }





    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            if (!gameOver)
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {

            if (!gameOver)
            {
                playerAudio.PlayOneShot(crashSound, 1.0f);
                explosionParticle.Play();
            }
           

            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            dirtParticle.Stop();

          
        }
    }
}
