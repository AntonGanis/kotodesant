using UnityEngine;

public class DestroyRocket : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        slehka u = col.GetComponent<slehka>();
        if (u != null)
        {
            Destroy(col.gameObject);
        }
    }
}
