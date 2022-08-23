using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyRadar : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Handheld.Vibrate();
            Destroy(gameObject, 3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
