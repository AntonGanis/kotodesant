using UnityEngine;

public class stalker : MonoBehaviour
{
    public float speed;

    Camera mainCamera;
    Vector3 targetPosition;

    [Header("Угол поворота корабля")]
    public float rotationSpeed;
    public float xTurn;

    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        targetPosition = transform.position;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        if (plane.Raycast(ray, out float distance))
        {
            Vector3 point = ray.GetPoint(distance);
            targetPosition = new Vector3(point.x, 0, transform.position.z);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        float X = targetPosition.x - transform.position.x;
        float Z = targetPosition.z - transform.position.z;

        Vector3 globalRotation = new Vector3(0, 180, 0);

        if (X > 1)
        {
            globalRotation.z = xTurn;
        }
        else if (X < -1)
        {
            globalRotation.z = -xTurn;
        }
        else
        {
            globalRotation.z = 0;
        }

        Quaternion targetRotation = Quaternion.Euler(globalRotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
