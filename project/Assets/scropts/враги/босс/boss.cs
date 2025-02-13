using UnityEngine;
using UnityEngine.UI;

public class boss : MonoBehaviour
{
    public HealthEnemy t;

    int max;
    int p1;
    bool pause1;
    int p2;
    bool pause2;

    public Animator head;
    public Slider slider;

    bool begin = true;
    public float timer1;
    public float timer2;
    public float time;

    GameObject vave0;
    public GameObject vave1;
    public GameObject vave2;

    public Transform Head;
    public GameObject Body;
    public GameObject DeadHead;
    public GameObject DeadBody;

    void Start()
    {
        max = t.health;
        p1 = max - max / 3;
        p2 = max - p1;

        slider.gameObject.SetActive(true);
        slider.maxValue = max;
        slider.value = max;
    }

    void Update()
    {
        int hp = t.health;
        slider.value = hp;
        if(hp > 0)
        {
            if (hp <= p1 && p1 != 0)
            {
                pause1 = true;
                vave1.SetActive(true);
                vave0 = vave1;
                p1 = 0;
            }
            if (hp <= p2 && p2 != 0)
            {
                pause2 = true;
                vave2.SetActive(true);
                vave0 = vave2;
                p2 = 0;
            }
            time += Time.deltaTime;
            if (!pause2 && !pause1)
            {
                if (time > timer1 && begin)
                {
                    begin = false;
                    head.SetInteger("Do", 0);
                    time = 0;
                }
                else if (time > timer2)
                {
                    int I = Random.Range(1, 4);
                    head.SetInteger("Do", I);
                    if (time > timer2 + 0.1f)
                    {
                        head.SetInteger("Do", 0);
                        time = 0;
                    }
                }
            }
            else
            {
                head.SetInteger("Do", 4);
                HealthEnemy[] enm = FindObjectsOfType<HealthEnemy>();
                if (enm.Length == 1 && vave0.transform.childCount == 0)
                {
                    vave0 = null;
                    vave1.SetActive(false);
                    vave2.SetActive(false);
                    head.SetInteger("Do", 0);
                    pause1 = false;
                    pause2 = false;
                    time = 0;
                }

            }
        }
        else
        {
            GameObject[] moveSports = GameObject.FindGameObjectsWithTag("точки");
            for (int i = 0; i < moveSports.Length; i++)
            {
                Loop o = Instantiate(DeadBody, moveSports[i].transform.position, moveSports[i].transform.rotation).GetComponent<Loop>();
                o.t = Random.Range(0.5f, 1f);
            }
            Instantiate(DeadHead, t.transform.position, t.transform.rotation);
            Destroy(Head.gameObject);
            Destroy(Body);
            Destroy(gameObject);
        }
    }
}
