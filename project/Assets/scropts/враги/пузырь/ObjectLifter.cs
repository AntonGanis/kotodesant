using UnityEngine;

public class ObjectLifter : MonoBehaviour
{
    public GameObject sphere;   
    public GameObject cube;     
    public GameObject culindre;     
    public HealthEnemy healthEnemy; 

    float sphereRadius;
    float minHeight;
    float maxHeight;

    int maxHealth;
    void Start()
    {
        sphereRadius = sphere.transform.localScale.x / 2;
        minHeight = sphere.transform.localPosition.y - sphereRadius;
        maxHeight = sphere.transform.localPosition.y + sphereRadius;
        maxHealth = healthEnemy.health;
    }

    void Update()
    {
        int health = healthEnemy.health;
        float height = Mathf.Lerp(maxHeight, minHeight, (float)health / maxHealth);
        cube.transform.localPosition = new Vector3(0, height, 0);


        float healthRatio = (float)health / maxHealth;

        float culindreScale = Mathf.Sin(healthRatio * Mathf.PI); 

        float scaleValue = sphereRadius * culindreScale * 2;
        culindre.transform.localScale = new Vector3(scaleValue, culindre.transform.localScale.y, scaleValue);

    }
}
