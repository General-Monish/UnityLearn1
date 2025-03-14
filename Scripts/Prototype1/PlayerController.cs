using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; // Required for UI Pointer Events

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] float HorsePower;
    float horizontalInput;
    float forwardInput;
    [SerializeField] float turnSpeed = 45f;
    [SerializeField] GameObject centerOfMass;
    Rigidbody rb;
    [SerializeField] TextMeshProUGUI SpeedText;
    [SerializeField] TextMeshProUGUI RpmText;
    bool isGrounded;
    bool isGameOver;
    [SerializeField] List<WheelCollider> ALLwheelColliders;
    int wheelsOnGround;

    bool moveForward = false;
    bool moveBackward = false;
    bool turnLeft = false;
    bool turnRight = false;

    [SerializeField] Button restartBtn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.transform.position;
        restartBtn.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        // Apply movement based on button state
        forwardInput = moveForward ? 1 : (moveBackward ? -1 : 0);
        horizontalInput = turnRight ? 1 : (turnLeft ? -1 : 0);

        if (IsGrounded())
        {
            rb.AddRelativeForce(Vector3.forward * forwardInput * HorsePower);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(rb.velocity.magnitude * 2.237f);  // Convert to mps
            SpeedText.SetText("Speed: " + speed + " mps");

            rpm = (speed % 30) * 40;
            RpmText.SetText("RPM: " + rpm);
        }
        GameOver();
    }

    bool IsGrounded()
    {
        wheelsOnGround = 0;

        foreach (WheelCollider wheel in ALLwheelColliders)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        return wheelsOnGround == 4;
    }

    // UI Pointer Down (Start Moving)
    public void OnMoveForwardPress() { moveForward = true; }
    public void OnMoveBackwardPress() { moveBackward = true; }
    public void OnTurnLeftPress() { turnLeft = true; }
    public void OnTurnRightPress() { turnRight = true; }

    // UI Pointer Up (Stop Moving)
    public void OnMoveForwardRelease() { moveForward = false; }
    public void OnMoveBackwardRelease() { moveBackward = false; }
    public void OnTurnLeftRelease() { turnLeft = false; }
    public void OnTurnRightRelease() { turnRight = false; }

    void GameOver()
    {
        if(transform.position.y <  -10)
        {
            isGameOver = true;
            RestartBtn();
        }
        else
        {
            isGameOver = false;
        }
    }

    void RestartBtn()
    {
        restartBtn.gameObject.SetActive(true);
        restartBtn.onClick.AddListener(()=>{
            SceneManager.LoadScene("Car");
        });
    }
}
