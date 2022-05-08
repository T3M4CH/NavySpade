using UnityEngine;
[CreateAssetMenu(menuName = "Pathfinder/Default")]
public class Pathfinder : ScriptableObject
{
    [SerializeField] private LayerMask layerMask;
    public virtual void Invoke(Vector3 from, Vector3 direction)
    {
        FindByRaycast(from, direction);
    }
    public bool FindByRaycast(Vector3 target, Vector3 direction)
    {
        Ray ray = new Ray(target, (direction - target).normalized);
        if (!Physics.Raycast(ray, (direction - target).magnitude,layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
