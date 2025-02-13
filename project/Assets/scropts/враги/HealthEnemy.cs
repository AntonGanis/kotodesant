using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public int health;
    public Transform booom;
    Push push;
    void Start()
    {
        push = GetComponent<Push>();
    }

    void Update()
    {

    }
    public void TakeDamage(int atak)
    {
        health -= atak;
        if (health <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        if(push != null)
        {
            push.No();
        }
        Instantiate(booom, transform.position, transform.rotation);
        if(transform.name == "босс")
        {
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
