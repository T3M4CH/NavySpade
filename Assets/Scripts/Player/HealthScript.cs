using UnityEngine;
using System.Collections;
public class HealthScript : MonoBehaviour
{
    [SerializeField] private HealthText healthText;
    [SerializeField] private PlayerInfoSO playerStats;
    [SerializeField] private IntChannelSO OnChangeHealth;
    [SerializeField] private AnimationCurve blinkingEffect;
    [SerializeField] private Collider objCollider;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject mesh;
    private void Start()
    {
        healthText = FindObjectOfType<HealthText>();
        OnChangeHealth.AddListener(OnGetDamage);
    }
    private void OnGetDamage(int damage)
    {
        if (healthText.count <= 0)
        {
            playerStats.InvokeDie();
            deathScreen.SetActive(true);
            Destroy(gameObject);
            return;
        }
        if (damage < 0)
        {
            objCollider.enabled = false;
            StartCoroutine(nameof(BlinkingEffect));
        }
    }
    private void OnDestroy()
    {
        OnChangeHealth.RemoveListener(OnGetDamage);
    }
    IEnumerator BlinkingEffect()
    {
        float currentTime = 0;
        while (currentTime < blinkingEffect.keys[blinkingEffect.keys.Length - 1].time)
        {
            if (blinkingEffect.Evaluate(currentTime) > .5f)
            {
                mesh.SetActive(true);
            }
            else
            {
                mesh.SetActive(false);
            }
            currentTime += Time.deltaTime;
            yield return Time.deltaTime;
        }
        objCollider.enabled = true;
    }
}
