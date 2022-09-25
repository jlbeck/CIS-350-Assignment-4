/*
 * Josh Beck
 * Prototype 3
 * Controls player movement, animations, and particle effects
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    private Animator playerAnimator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {

        //set a reference to rigidbody component
        rb = GetComponent<Rigidbody>();

        jumpForceMode = ForceMode.Impulse;

        //modify gravity
        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }

        //set reference for animator
        playerAnimator = GetComponent<Animator>();

        //begin running on start
        playerAnimator.SetFloat("Speed_f", 1.0f);

        //set reference to playerAudio
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;

            //start running jump animation
            playerAnimator.SetTrigger("Jump_trig");

            //stop playing dirt particle
            dirtParticle.Stop();

            //play jump SE
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            //start playing dirt particle
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game over!");
            gameOver = true;

            //play death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            //play explosion particle
            explosionParticle.Play();

            //stop dirt particle
            dirtParticle.Stop();

            //play crash SE
            playerAudio.PlayOneShot(crashSound, 1.0f);

        }
    }
}
