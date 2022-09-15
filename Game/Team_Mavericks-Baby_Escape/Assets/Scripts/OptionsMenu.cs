using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    public void SetAudio(bool _isAudio)
    {
        if (_isAudio == false)
        {
            _audio.Stop();
            Debug.Log(_isAudio);
        }
    }
    
}
