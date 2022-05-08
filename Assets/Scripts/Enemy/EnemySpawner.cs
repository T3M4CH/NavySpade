using UnityEngine;
public class EnemySpawner : Spawner
{
    [SerializeField] private EnemyCollider enemy;
    [SerializeField] private Vector3[] spawnPositions;
    [SerializeField] private int maxCount;
    private int count;
    private void Start()
    {
        InvokeRepeating(nameof(InstantiateObject), 5, 5);
    }
    protected override void InstantiateObject()
    {
        count += 1;
        if (count > maxCount)
        {
            CancelInvoke();
            return;
        }
        Instantiate(enemy, spawnPositions[Random.Range(0, spawnPositions.Length)], Quaternion.identity);
    }
}
