using UnityEngine;

public class TaranEnemy : MonoBehaviour
{
    public WarningPoint[] points;
    public GameObject o;

    WarningPoint start;
    public float time;
    public float predel;
    public float predelAtak;

    void Start()
    {
        time = Random.Range(0f, predel);
        points = FindObjectsOfType<WarningPoint>();
        transform.parent = null;
    }

    void Update()
    {
        if (transform.parent == null)
        {
            if (time > predel)
            {
                o.SetActive(false);
                int I = Random.Range(0, points.Length);
                start = points[I];
                if (start.enm != null)
                {
                    start = null;
                }
                else
                {
                    start.Give(gameObject.GetComponent<TaranEnemy>());
                }
            }
            else
            {
                time += Time.deltaTime;
            }
        }
        else
        {
            time += Time.deltaTime;
            o.SetActive(true);
        }
    }
}
