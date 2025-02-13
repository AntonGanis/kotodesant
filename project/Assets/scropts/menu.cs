using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void Restart()
    {
        int sceneNumber = SceneManager.GetActiveScene().buildIndex;
        Application.LoadLevel(sceneNumber);
    }
    public void Load(int sceneNumber)
    {
        Application.LoadLevel(sceneNumber);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
