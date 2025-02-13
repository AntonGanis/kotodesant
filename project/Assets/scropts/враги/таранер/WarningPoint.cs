using UnityEngine;

public class WarningPoint : MonoBehaviour
{
    public TaranEnemy enm;
    public GameObject animator;
    public WarningPoint p;

    forward fw;
    float pred;

    void Start()
    {
        animator.SetActive(false);
        transform.parent = null;
    }
    public void Give(TaranEnemy enm0)
    {
        if((p != null && p.enm == null) || p == null)
        {
            enm = enm0;
            fw = enm.GetComponent<forward>();
            fw.enabled = false;
            enm.transform.parent = transform;
            enm.transform.position = transform.position;
            enm.transform.rotation = transform.rotation;
            enm.time = 0;
            pred = enm.predelAtak;
            animator.SetActive(true);
        }
    }
    void Update()
    {
        if (enm != null)
        {
            if(enm.time > pred)
            {
                animator.SetActive(false);
                fw.enabled = true;
                enm.transform.parent = null;
                enm.time = 0;
                enm = null;
            }
        }
        else
        {
            animator.SetActive(false);
        }
    }
}
