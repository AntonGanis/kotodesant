using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CatManager : MonoBehaviour
{
    public bool free = true;
    public bool shoot;
    GameObject img0;
    public GameObject img1;
    public GameObject img2;
    public Slider slider;

    CatManager[] icons;
    int I;
    public float time;
    public float timePlus;


    void Start()
    {
        img0 = transform.GetChild(0).gameObject;
        icons = FindObjectsOfType<CatManager>().OrderBy(obj => obj.transform.GetSiblingIndex()).ToArray();
        slider.maxValue = timePlus;
        slider.value = timePlus;
        for (int i = 0; i < icons.Length; i++)
        {
            if (icons[i] == gameObject.GetComponent<CatManager>())
            {
                I = i;
            }
        }
    }

    void Update()
    {
        if(free == false)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                img1.SetActive(false);
                img2.SetActive(true);
                if (shoot)
                {
                    free = true;
                    img0.SetActive(false);
                    img2.SetActive(false);
                    shoot = false;
                }
            }
            slider.value = time;

            int j = I - 1;
            if (I != 0 && icons[j].free == true)
            {
                icons[j].time = time;
                icons[j].img1.SetActive(true);
                icons[j].img0.SetActive(true);
                icons[j].free = false;

                time = 0;
                img1.SetActive(false);
                img2.SetActive(false);
                img0.SetActive(false);
                free = true;
            }
        }
        
    }

    public void Give()
    {
        time = timePlus;
        free = false;
        img0.SetActive(true);
        img1.SetActive(true);
    }
}
