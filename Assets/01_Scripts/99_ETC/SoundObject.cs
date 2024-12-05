using UnityEngine;

public class SoundObject : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

    }

    private void OnEnable()
    {
        _audioSource.Play();
    }
}
