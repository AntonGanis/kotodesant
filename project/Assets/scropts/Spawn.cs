using UnityEngine;

public class Spawn : MonoBehaviour
{
    GameObject[] vave;
    HealthEnemy[] enm;

    Move plar;

    public GameObject win;

    public float igleTime;
    float time;
    public int I;
    void Start()
    {
        vave = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            vave[i] = transform.GetChild(i).gameObject;
        }

        if (vave.Length > 0)
        {
            vave[I].SetActive(true);
            I++;
        }
        enm = FindObjectsOfType<HealthEnemy>();
        plar = FindObjectOfType<Move>();

    }

    void Update()
    {
        enm = FindObjectsOfType<HealthEnemy>();
        if (enm.Length == 0 && vave[I - 1].transform.childCount == 0)
        {
            if(time > igleTime)
            {
                vave[I - 1].SetActive(false);
                vave[I].SetActive(true);
                I++;
                time = 0;
                if (I == vave.Length +1)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                time += Time.deltaTime;
            }
            
        }
        else if (enm.Length == 0 && (I == 10 || I == 11))
        {
            plar.enabled = false;
            win.SetActive(true);
        }
    }
}
