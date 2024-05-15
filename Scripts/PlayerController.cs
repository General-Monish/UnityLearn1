using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    float horizontalInput;
    float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moving vehicle forward 
        Movement();
        Rotate();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.right * x * Time.deltaTime * moveSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed * horizontalInput);
    }
}
