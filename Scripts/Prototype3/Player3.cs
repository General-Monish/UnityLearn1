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

    AudioSource playAudio;

    [SerializeField]
    private ParticleSystem explosionPrefab;
    [SerializeField]
    private ParticleSystem dirtParticlePrefab;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    // Start is called before the first frame update
    void Start()
    {
        playAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver)
        {
            playAudio.PlayOneShot(jumpSound, 1f);
            animator.SetTrigger("Jump_trig");
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGround = false;
            dirtParticlePrefab.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            dirtParticlePrefab.Play();
            isGround = true;
        }
        else if (collision.collider.CompareTag("obs"))
        {
            playAudio.PlayOneShot(crashSound, 1f);
            Debug.Log("Game Over");
            gameOver = true;
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
            explosionPrefab.Play();
            dirtParticlePrefab.Stop();
        }
    }
}
