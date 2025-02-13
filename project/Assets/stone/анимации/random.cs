using UnityEngine;

public class random : MonoBehaviour
{
    void Start()
    {
        int o = Random.Range(1, 5);
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetInteger("Do", o);
    }
}
