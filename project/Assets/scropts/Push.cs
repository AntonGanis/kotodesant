using UnityEngine;
using System.Collections;

public class Push : MonoBehaviour
{
    public float speed = 5f; 
    public float pushDuration = 2f;

    Move Game;
    void Start()
    {
        Game = GameObject.FindGameObjectWithTag("Player").GetComponent<Move>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Game != null && other.GetComponent<Move>() == Game )
        {
            Vector3 pushDirection = (other.transform.position - transform.position).normalized;
            StartCoroutine(PushObject(other.gameObject, pushDirection));
            Game.enabled = false;
        }
    }

    private IEnumerator PushObject(GameObject target, Vector3 direction)
    {
        float elapsedTime = 0f;
        Rigidbody rb = target.GetComponent<Rigidbody>();

        if (rb == null)
        {
            rb = target.AddComponent<Rigidbody>(); 
            rb.isKinematic = true;
        }

        while (elapsedTime < pushDuration)
        {
            target.transform.position += direction * speed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Game.enabled = true;
    }
    public void No()
    {
        Game.enabled = true;
    }
}
