using UnityEngine;
[CreateAssetMenu(fileName = "RippleEffect")]
public class RippleScript : ScriptableObject
{
    [SerializeField] private AudioClip OnSuccess, OnFailure;
    [SerializeField] private ParticleSystem rippleEffect;
    [SerializeField] private BoolChannelSO boolChannel;
    [SerializeField] private VectorChannelSO vectorChannel;
    [SerializeField] private AudioChannelSO audioChannel;
    private void Awake()
    {
        vectorChannel.AddListener(SpawnRipple);
        boolChannel.AddListener(PlaySound);
    }
    private void PlaySound(bool state)
    {
        audioChannel.PlayClip(state ? OnSuccess : OnFailure);
    } 
    private void SpawnRipple(Vector3 position)
    {
        ParticleSystem ripple = Instantiate(rippleEffect, position + Vector3.up / 2, Quaternion.Euler(-90,0,0));
        Destroy(ripple.gameObject, 2);
    }
    private void OnDisable()
    {
        vectorChannel.RemoveListener(SpawnRipple);
        boolChannel.RemoveListener(PlaySound);
    }

}
