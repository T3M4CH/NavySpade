using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private Pathfinder pathFinder;
    private Vector3 destination ;
    private bool farDistance => (transform.position - destination).magnitude > 0.2f;

    private void Start()
    {
        destination = transform.position + transform.forward / 2;
        pathFinder.FindByRaycast(transform.position, destination);
    }
    private void Update()
    {
        if (farDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
        }
        else
        {
            if (pathFinder.FindByRaycast(destination, destination + transform.forward))
            {
                destination += transform.forward;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            }
        }
    }
}
