using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public bool enemy;
    public bool kanikadze;
    public GameObject boom;

    void OnTriggerEnter(Collider col)
    {
        if (boom != null && !kanikadze && !col.gameObject.GetComponent<Damage>() && !col.gameObject.GetComponent<HealthEnemy>())
        {
            Destroy(gameObject);
        }
        if (col.gameObject.GetComponent<Health>() && enemy)
        {
            col.GetComponent<Health>().TakeDamage(damage);
            if(boom != null)
            {
                Instantiate(boom, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else if (col.gameObject.GetComponent<HealthEnemy>() && !enemy)
        {
            col.GetComponent<HealthEnemy>().TakeDamage(damage);
        }
    }
}
