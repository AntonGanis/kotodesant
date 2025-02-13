using UnityEngine;

public class Shoota : MonoBehaviour
{
    public Transform[] spawn;
    public Transform bullet;
    public Transform eff;
    public float time;
    public float predel;

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time > predel)
        {
            for (int i = 0; i < spawn.Length; i++)
            {
                Instantiate(bullet, spawn[i].position, spawn[i].rotation);
                Instantiate(eff, spawn[i].position, spawn[i].rotation, spawn[i]);
            }
            time = 0f;
        }

    }
}
