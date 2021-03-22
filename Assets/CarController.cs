using UnityEngine;

public class CarController : MonoBehaviour
{

    private float horizontalInput; // keys a and d 
    private float verticalInput; // keys w and s
    private float steeringAngle;
    private float brakeInput;

    public WheelCollider frontWheelLeft, frontWheelRight;
    public WheelCollider rearWheelLeft, rearWheelRight;
    public Transform frontWheelLeftTransform, frontWheelRightTransform;
    public Transform rearWheelLeftTransform, rearWheelRightTransform;
    public Rigidbody rb;
    public float maxSteeringAngle = 30; // the speed to steering
    public float maxEnginePower = 90;
    public float brakeForce = 90000;
    public float currentBrakeForce;

    public void GetInput() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //brakeInput = Input.GetKey(KeyCode.Space);
        brakeInput = Input.GetAxis("Jump");
    }

    private void Steer() {
        steeringAngle = maxSteeringAngle * horizontalInput;
        frontWheelLeft.steerAngle = steeringAngle;
        frontWheelRight.steerAngle = steeringAngle;
    }

    private void Accelerate() {

        //Debug.Log(rearWheelLeft.motorTorque);
        Debug.Log(brakeInput);
        //Debug.Log(verticalInput);
        //if (verticalInput > 0.01) {
        //    brakeInput = false;
        //}
        if (brakeInput == 1)
        {
            //Debug.Log("Spacebar was pressed");
            currentBrakeForce = brakeForce;
            rearWheelLeft.brakeTorque = currentBrakeForce;
            rearWheelRight.brakeTorque = currentBrakeForce;

            rearWheelLeft.motorTorque = 1;
            rearWheelRight.motorTorque = 1;


            Debug.Log(rearWheelLeft.motorTorque);
        }
        else
        {
            rearWheelLeft.brakeTorque = 0;
            rearWheelRight.brakeTorque = 0;

            rearWheelLeft.motorTorque = verticalInput * maxEnginePower;
            rearWheelRight.motorTorque = verticalInput * maxEnginePower;
            //brakeInput = false;
            currentBrakeForce = 0f;
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
        //Brake();
        UpdateWheelPositions();
    }
}
