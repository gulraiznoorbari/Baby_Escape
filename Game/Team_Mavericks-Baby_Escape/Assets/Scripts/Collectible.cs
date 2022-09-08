using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 120 * Time.deltaTime, 0);
    }
}
