using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject _levelCompletionMenu;

    private void Awake()
    {
        _particleSystem.Play();
    }

    private void Update()
    {
        transform.Rotate(0, 120 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Collect");
            FindObjectOfType<AudioManager>().StopPlaying("Laser");
            _particleSystem.Stop();
            StartCoroutine(NextLevel(other));
        }
    }

    private IEnumerator NextLevel(Collider other)
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
        Destroy(other.gameObject);
        _levelCompletionMenu.SetActive(true);
    }
}
