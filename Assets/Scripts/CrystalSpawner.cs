using UnityEngine;
public class CrystalSpawner : Spawner
{
    [SerializeField] private VoidChannelSO SpawnCrystal;
    [SerializeField] private GameObject crystalPrefab;
    [SerializeField] private LayerMask layerMask;
    private float currentTime = 0;
    private float delay;
    private Vector3 GetRandomVector => new Vector3(Random.Range(-8f, 8f), .5f, Random.Range(-8f, 8f));
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            InstantiateObject();
        }
        delay = Random.Range(4, 7);
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > delay)
        {
            currentTime = 0;
            delay = Random.Range(4, 7);
            InstantiateObject();
        }
    }

    protected override void InstantiateObject()
    {
        Vector3 spawnPos = GetRandomVector;
        if (Physics.CheckSphere(spawnPos, 2, layerMask))
        {
            return;
        }
        GameObject tmp = Instantiate(crystalPrefab, spawnPos, Quaternion.identity);
        SpawnCrystal.Invoke();
    }
}