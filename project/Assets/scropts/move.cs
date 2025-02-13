using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed1; 
    public float speed2; 
    public Camera mainCamera;

    private Vector3 targetPosition;
    private float currentSpeed;

    [Header("Угол поворота корабля")]
    public float rotationSpeed;
    public float xTurn;
    public float zTurnForward;
    public float zTurnBack;

    [Header("Настройки ускорения")]
    public float dist; 
    public float accelerationTime; 

    private float accelerationRate;

    void Start()
    {
        targetPosition = transform.position;
        currentSpeed = speed1; 
        accelerationRate = (speed2 - speed1) / accelerationTime;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 point = ray.GetPoint(distance);
            targetPosition = new Vector3(point.x, 0, point.z);
        }

        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        if (distanceToTarget > dist)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, speed2, accelerationRate * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, speed1, accelerationRate * Time.deltaTime);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

        float X = targetPosition.x - transform.position.x;
        float Z = targetPosition.z - transform.position.z;

        Vector3 globalRotation = Vector3.zero;

        if (X > 1)
        {
            globalRotation.z = -xTurn;
        }
        else if (X < -1)
        {
            globalRotation.z = xTurn;
        }
        else
        {
            globalRotation.z = 0;
        }

        if (Z < -1)
        {
            globalRotation.x = -zTurnBack;
        }
        else if (Z > 1)
        {
            globalRotation.x = zTurnForward;
        }
        else
        {
            globalRotation.x = 0;
        }

        Quaternion targetRotation = Quaternion.Euler(globalRotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
