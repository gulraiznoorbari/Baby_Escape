using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioClip _collectibleSound;
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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _audioSource.PlayOneShot(_collectibleSound);
            _particleSystem.Stop();
            Destroy(gameObject);
            StartCoroutine(NextLevel());
        }
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
