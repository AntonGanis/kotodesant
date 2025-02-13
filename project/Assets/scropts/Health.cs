using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    int healthMax;
    public Slider slider;
    public Transform booom;
    public GameObject Lose;


    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    int p1;
    int p2;
    void Start()
    {
        QualitySettings.SetQualityLevel(5, true);
        slider.maxValue = health;
        slider.value = health;
        healthMax = health;

        p1 = healthMax - healthMax / 3;
        p2 = healthMax - p1;
    }

    public void TakeDamage(int atak)
    {
        health -= atak;
        if (health > p1)
        {
            o1.SetActive(true);
            o2.SetActive(false);
            o3.SetActive(false);
        }
        else if(health <= p1 && health >= p2) 
        {
            o1.SetActive(false);
            o2.SetActive(true);
            o3.SetActive(false);
        }
        else if (health <= p2)
        {
            o1.SetActive(false);
            o2.SetActive(false);
            o3.SetActive(true);
        }
        if (health <= 0)
        {
            Death();
        }
        else if (health > healthMax)
        {
            health = healthMax;
        }
        slider.value = health;
    }
    void Death()
    {
        Instantiate(booom, transform.position, transform.rotation);
        Lose.SetActive(true);
        gameObject.SetActive(false);
    }
}
