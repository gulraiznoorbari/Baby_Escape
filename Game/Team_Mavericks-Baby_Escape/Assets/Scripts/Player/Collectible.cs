using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject _levelCompletionMenu;
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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
            _audioSource.Play();
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
