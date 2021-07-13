using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject objectToFollow;
    public Vector3 offset;
    Vector3 targetPos;


    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow)
        {
            Vector3 currentPositionOfCamera = transform.position;
            currentPositionOfCamera.z = objectToFollow.transform.position.z;    //get the z-position of the camera

            Vector3 targetDirection = (objectToFollow.transform.position - currentPositionOfCamera);

            interpVelocity = targetDirection.magnitude * 5f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

        }
    }
}