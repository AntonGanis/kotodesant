using UnityEngine;

public class forward : MonoBehaviour
{
    public int Speed;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
