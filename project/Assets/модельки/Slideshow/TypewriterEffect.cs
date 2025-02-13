using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private string text; 
    [SerializeField] private float interval = 0.1f; 

    private Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();

        if (uiText != null)
        {
            StartCoroutine(ShowText());
        }
        else
        {
            Debug.LogError("Компонент Text не найден на объекте!");
        }
    }

    IEnumerator ShowText()
    {
        uiText.text = "";
        foreach (char c in text)
        {
            uiText.text += c;
            yield return new WaitForSeconds(interval);
        }
    }
}
