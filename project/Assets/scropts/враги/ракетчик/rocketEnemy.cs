using UnityEngine;

public class rocketEnemy : MonoBehaviour
{
    public float zStop;
    forward fw;
    Vector3 targetPosition;


    void Start()
    {
        targetPosition = new Vector3(transform.position.x, 0, zStop);
        fw = GetComponent<forward>();
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
        if(distanceToTarget <= 1)
        {
            fw.enabled = false;
            gameObject.GetComponent<rocketEnemy>().enabled = false;
        }
    }
}
