using UnityEngine;
public class EnemyCollider : MonoBehaviour
{
    [SerializeField] private AudioChannelSO audioChannel;
    [SerializeField] private AudioClip OnTouch;
    [SerializeField] private IntChannelSO GiveHealth;
    [SerializeField] private Rigidbody rigidBody;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GiveHealth.Invoke(-1);
            audioChannel.PlayClip(OnTouch);
        }
    }
}
