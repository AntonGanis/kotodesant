using UnityEngine;

public class Loop : MonoBehaviour
{
    public Animator head;
    public float t;
    void Start()
    {
        head.SetFloat("ata", t);
    }
}
