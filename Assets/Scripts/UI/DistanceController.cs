using UnityEngine;
using TMPro;
public class DistanceController : MonoBehaviour
{
    [SerializeField] private PlayerInfoSO OnPlayerDead;
    [SerializeField] private TextMeshProUGUI crystalText, enemyText;
    [SerializeField] private Transform player;
    [SerializeField] private NearestFinder finder;
    [SerializeField] private VoidChannelSO OnCrystalsUpdate;
    private CrystalCollider closestCrystal;
    private EnemyCollider closestEnemy;
    private void Start()
    {
        OnPlayerDead.AddListener(() => this.enabled = false);
        OnCrystalsUpdate.AddListener(UpdateClosestObjects);
        InvokeRepeating(nameof(UpdateClosestObjects), 1, 2);
    }
    private void Update()
    {
        if (closestCrystal != null)
        {
            crystalText.text = string.Format("{0:0.00}", (player.position - closestCrystal.transform.position).magnitude);
        }
        if (closestEnemy != null)
        {
            enemyText.text = string.Format("{0:0.00}", (player.position - closestEnemy.transform.position).magnitude);
        }
    }
    private void UpdateClosestObjects()
    {
        closestCrystal = finder.FindNearest<CrystalCollider>(player);
        closestEnemy = finder.FindNearest<EnemyCollider>(player);
    }
    private void OnDisable()
    {
        CancelInvoke();
        OnPlayerDead.RemoveListener(() => this.enabled = false);
        OnCrystalsUpdate.RemoveListener(UpdateClosestObjects);
    }
}
