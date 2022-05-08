using UnityEngine;
public class CrystalCollider : MonoBehaviour
{
    [SerializeField] private VoidChannelSO UpdateCrystals;
    [SerializeField] private AudioChannelSO audioChannel;
    [SerializeField] private AudioClip OnTake, OnDestroy;
    [SerializeField] private IntChannelSO GiveHealth, GiveExp;
    [SerializeField] private int amountExp = 30;
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                GiveHealth.Invoke(1);
                GiveExp.Invoke(amountExp);
                audioChannel.PlayClip(OnTake);
                break;
            case "Enemy":
                audioChannel.PlayClip(OnTake);
                break;
        }
        Destroy(gameObject);
        UpdateCrystals.Invoke();
    }
}
