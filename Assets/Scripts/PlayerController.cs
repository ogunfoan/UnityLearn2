using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem dirtParticles;
    public ParticleSystem explosion;
    public float jumpforce = 10f;
    private Rigidbody PlayerRB;
    private Animator playerAnim;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerAudio;
    public float gravityModifier;
    public bool isGrounded;
    public bool gameOver = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier; 
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            PlayerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse); //ForceMode.Impulse hemen aninda kullanimlarda ise yariyor
            isGrounded = false;
            playerAnim.SetBool("Jump_b", true);
            Invoke("Animsanim", 0.5f);
            playerAudio.PlayOneShot(jumpSound, 1f);
            dirtParticles.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
            dirtParticles.Play();
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b" , true);
            playerAnim.SetInteger("DeathType_int" ,1);
            explosion.Play();
            dirtParticles.Stop();
            playerAudio.PlayOneShot(crashSound, 1f);
        }
    }

    private void Animsanim()
    {
        playerAnim.SetBool("Jump_b", false);
    }
}
