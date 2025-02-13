using UnityEngine;

public class slehka : MonoBehaviour
{
    public Transform target;
    public float speed;
    public bool lockX;
    public bool lockY;
    public bool lockZ;
    
    Transform plar;

    void Start()
    {
        plar = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (target == null)
        {
            target = plar;
        }
    }

    void Update()
    {
        if(target != null)
        {
            Vector3 direction = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            Vector3 currentRotation = transform.rotation.eulerAngles;

            if (lockX) currentRotation.x = targetRotation.eulerAngles.x;
            if (lockY) currentRotation.y = targetRotation.eulerAngles.y;
            if (lockZ) currentRotation.z = targetRotation.eulerAngles.z;

            Quaternion newRotation = Quaternion.Euler(currentRotation);

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

