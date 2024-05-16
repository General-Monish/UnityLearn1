using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float horizontalInput;
    [SerializeField] float xRange = 17f;
    [SerializeField] Transform shotPoint;
    [SerializeField] GameObject foodPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        SpawnFood();
    }

    void HandleMovement()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);
    }

    void SpawnFood()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(foodPrefab,shotPoint.position,Quaternion.identity);
        }
    }
}
