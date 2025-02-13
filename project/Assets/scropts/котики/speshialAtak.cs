using UnityEngine;

public class speshialAtak : MonoBehaviour
{
    public CatManager cat;
    public Transform spawn;
    public Transform bullet;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(cat.time <= 0 && cat.free == false)
            {
                Instantiate(bullet, spawn.position, spawn.rotation);
                cat.shoot = true;
            }
        }
    }
}
