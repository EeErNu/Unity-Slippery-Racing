using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void LookAtTarget()
    {
        Vector3 _lookDirection = playerCar.position - transform.position;
        Quaternion quaternion = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, lookSpeed * Time.deltaTime);
    }

    public void MoveToTarget()
    {
        //Vector3 targetPosition = playerCar.position + playerCar.forward * offset.z + playerCar.right + offset.x + playerCar.up * offset.y;
        //transform.rotation = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        Vector3 targetPosition = playerCar.position + 
            playerCar.forward * offset.z +
            playerCar.right * offset.x + 
            playerCar.up * offset.x;

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }

    public Transform playerCar;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;
}
