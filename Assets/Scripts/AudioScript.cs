using UnityEngine;
public class AudioScript : MonoBehaviour
{
    [SerializeField] private AudioChannelSO audioChannel;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioChannel.AddListener(PlayClip);
    }
    private void PlayClip(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
    private void OnEnable()
    {
        audioChannel.AddListener(PlayClip);
    }
    private void OnDisable()
    {
        audioChannel.RemoveListener(PlayClip);
    }
}