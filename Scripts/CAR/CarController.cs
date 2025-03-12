using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeft, frontRight, rearLeft, rearRight;
    public Transform FLT, FRT, RLT, RRT; // Wheel Transforms
    public float motorForce = 1500f;
    public float maxSteeringAngle = 30f;

    private float acceleration;
    private float steering;

    void Update()
    {
        acceleration = Input.GetAxis("Vertical") * motorForce;
        steering = Input.GetAxis("Horizontal") * maxSteeringAngle;

        ApplyDrive();
        ApplySteering();
        UpdateWheels();
    }

    void ApplyDrive()
    {
        rearLeft.motorTorque = acceleration;
        rearRight.motorTorque = acceleration;
    }

    void ApplySteering()
    {
        frontLeft.steerAngle = steering;
        frontRight.steerAngle = steering;
    }

    void UpdateWheels()
    {
        UpdateWheelPose(frontLeft, FLT);
        UpdateWheelPose(frontRight, FRT);
        UpdateWheelPose(rearLeft, RLT);
        UpdateWheelPose(rearRight, RRT);
    }

    void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
}
