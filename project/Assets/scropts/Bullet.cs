using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Speed;
    Vector3 lastPos;
    public LayerMask ignoreLayer;

    public int damage;
    public bool enemyDamage;


    void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        RaycastHit hit;
        Debug.DrawLine(lastPos, transform.position);

        if (Physics.Linecast(lastPos, transform.position, out hit, ~ignoreLayer))
        {
            if(hit.transform.GetComponent<HealthEnemy>() && !enemyDamage)
            {
                hit.transform.GetComponent<HealthEnemy>().TakeDamage(damage);
            }
            else if (hit.transform.GetComponent<Health>() && enemyDamage)
            {
                hit.transform.GetComponent<Health>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        lastPos = transform.position;
    }
}
