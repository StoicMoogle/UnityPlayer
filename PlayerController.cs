using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRB;
    Animator playerAnim;

    float speed;
    public float walkSpeed = 5f;
    public float runSpeed = 12f;
    public float jumpForce = 5f;
    public int maxHealth = 100;
    public int currentHealth;
    bool canJump = true;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            playerAnim.SetBool("isRunning", true);
        }
        else
        {
            speed = walkSpeed;
            playerAnim.SetBool("isRunning", false);
        }

       if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            playerAnim.SetBool("isWalking", true);
        }

       else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            playerAnim.SetBool("isWalking", true);
        }

        else
        {
            playerAnim.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }

        if(collision.gameObject.CompareTag("Danger"))
        {
            currentHealth -= 20;
            Destroy(collision.gameObject);
        }
    }
}
