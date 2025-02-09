using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpforce = 10f;
    private Rigidbody PlayerRB;
    public float gravityModifier;
    public bool isGrounded;
    public bool gameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            PlayerRB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse); //ForceMode.Impulse hemen aninda kullanimlarda ise yariyor
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true;
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
        }
    }
}
