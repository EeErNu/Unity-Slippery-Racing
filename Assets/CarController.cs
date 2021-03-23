using UnityEngine;

public class CarController : MonoBehaviour {
    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;
    private float brakeInput;

    public WheelCollider frontWheelLeft, frontWheelRight;
    public WheelCollider rearWheelLeft, rearWheelRight;
    public Transform frontWheelLeftTransform, frontWheelRightTransform;
    public Transform rearWheelLeftTransform, rearWheelRightTransform;
    public Rigidbody rb;
    public float maxSteeringAngle = 30;
    public float maxEnginePower = 90;
    public float brakeForce = 90000;
    public float currentBrakeForce;

    public void GetInput() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        brakeInput = Input.GetAxis("Jump");
    }

    private void Steer() {
        steeringAngle = maxSteeringAngle * horizontalInput;
        frontWheelLeft.steerAngle = frontWheelRight.steerAngle  = steeringAngle;
    }

    private void Accelerate() {
        if (brakeInput == 1) {
            currentBrakeForce = brakeForce;
            rearWheelLeft.brakeTorque = rearWheelRight.brakeTorque = currentBrakeForce;
            rearWheelLeft.motorTorque = rearWheelRight.motorTorque = 1;
        } else {
            rearWheelLeft.brakeTorque = rearWheelRight.brakeTorque = 0;
            rearWheelLeft.motorTorque = rearWheelRight.motorTorque = verticalInput * maxEnginePower;
        }
    }

    private void UpdateWheelPositions() {
        UpdateWheelPosition(frontWheelLeft, frontWheelLeftTransform);
        UpdateWheelPosition(frontWheelRight, frontWheelRightTransform);
        UpdateWheelPosition(rearWheelLeft, rearWheelLeftTransform);
        UpdateWheelPosition(rearWheelRight, rearWheelRightTransform);
    }

    private void UpdateWheelPosition(WheelCollider _collider, Transform _transform) {
        Vector3 _pos = transform.position;
        Quaternion _quat = transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);
        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate() {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPositions();
    }
}
