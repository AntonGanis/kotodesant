using UnityEngine;
using System.Linq;
public class Cat : MonoBehaviour
{
    CatManager[] cats;
    public GameObject o;
    void Start()
    {
        cats = FindObjectsOfType<CatManager>().OrderBy(obj => obj.transform.GetSiblingIndex()).ToArray();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<Health>())
        {
            for (int i = 0; i < cats.Length; i++)
            {
                if (cats[i].free == true)
                {
                    cats[i].Give();
                    break;
                }
            }
            Destroy(o);
            Destroy(gameObject.GetComponent<Cat>());
        }
    }
}
