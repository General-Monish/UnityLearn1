using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3 : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float jumpSpeed;
    [SerializeField]
    float gravityModifier;
    [HideInInspector]
    public bool gameOver;

    bool isGround = true;
    Animator animator;

    [SerializeField]
    private ParticleSystem explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver)
        {
            animator.SetTrigger("Jump_trig");
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGround = true;
        }else if (collision.collider.CompareTag("obs"))
        {
            Debug.Log("Game Over");
            gameOver=true;
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            explosionPrefab.Play();
        }
    }
}
