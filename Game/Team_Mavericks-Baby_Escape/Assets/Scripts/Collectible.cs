using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 120 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine(NextLevel());
        }
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.05f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
