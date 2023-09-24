using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(int index)
    {
        if (index < 0 || index > SceneManager.sceneCount) Debug.Log("Index out of range");
        else
        {
            SceneManager.LoadScene(index);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
