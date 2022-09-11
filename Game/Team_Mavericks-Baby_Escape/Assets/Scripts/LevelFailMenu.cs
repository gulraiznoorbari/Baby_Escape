using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailMenu : MonoBehaviour
{
    public void CurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
