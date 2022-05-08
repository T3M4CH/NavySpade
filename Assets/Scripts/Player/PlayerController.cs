using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInfoSO playerStats;
    [SerializeField] private VectorChannelSO vectorChannel;
    [SerializeField] private RippleScript rippleSO;
    public bool farDistance => (transform.position - destination).magnitude > 0.1f;
    private Vector3 destination;
    private float speed;
    private void Start()
    {
        rippleSO = Instantiate(rippleSO);
        destination = transform.position;
        speed = playerStats.MoveSpeed;
        vectorChannel.AddListener(SetDestination);
    }
    private void Update()
    {
        if (farDistance)
        {
            Move(destination);
        }
    }
    private void SetDestination(Vector3 direction)
    {
        destination = direction;
        transform.LookAt(direction);
    }
    private void Move(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, Time.fixedDeltaTime * speed);
    }
    private void OnDestroy()
    {
        vectorChannel.RemoveListener(SetDestination);
        Destroy(rippleSO);
    }
}