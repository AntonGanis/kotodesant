using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag =="Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
