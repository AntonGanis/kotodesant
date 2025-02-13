using UnityEngine;

public class Healing : MonoBehaviour
{
    public int healing;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Health>())
        {
            col.GetComponent<Health>().TakeDamage(healing*-1);
            Destroy(gameObject);
        }
    }
}
