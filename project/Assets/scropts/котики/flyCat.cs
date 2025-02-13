using UnityEngine;

public class flyCat : MonoBehaviour
{
    public slehka sl;
    public catAtak att;
    void Start()
    {
        HealthEnemy[] enm;
        enm = FindObjectsOfType<HealthEnemy>();
        if(enm.Length > 0)
        {
            float distanceToTarget, min = 0;
            int j = 0;
            for (int i = 0; i < enm.Length; i++)
            {
                if (enm[i].gameObject.GetComponent<slehka>() == null && enm[i].enabled == true && enm[i].transform.name != "пузырь(Clone)")
                {
                    distanceToTarget = Vector3.Distance(transform.position, enm[i].transform.position);
                    if (distanceToTarget < min)
                    {
                        min = distanceToTarget;
                        j = i;
                    }
                }
            }
            sl.target = enm[j].transform;
            att.vrag = enm[j];
        }
        else
        {
            sl.enabled = false;
            att.enabled = false;
            gameObject.GetComponent<Delate>().enabled = false;
        }
    }
}
