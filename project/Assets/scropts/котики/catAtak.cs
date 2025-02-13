using UnityEngine;

public class catAtak : MonoBehaviour
{
    int damage;
    public HealthEnemy vrag;

    private void Start()
    {
        damage = vrag.health;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<HealthEnemy>() == vrag && vrag != null && vrag.transform.name != "����")
        {
            vrag.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if(col.tag == "WALL")
        {
            Destroy(gameObject);
        }
        else if (vrag.transform.name == "����")
        {
            vrag.TakeDamage(100);
            Destroy(gameObject);
        }
    }
}
