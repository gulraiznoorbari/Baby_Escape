using UnityEngine;

public class FreezeTime : MonoBehaviour
{
    [SerializeField] private GameObject _popupMenu;

    // Update is called once per frame
    void Update()
    {
        if (_popupMenu.activeInHierarchy)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }
}
