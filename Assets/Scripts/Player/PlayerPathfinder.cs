using UnityEngine;
[CreateAssetMenu(menuName = "Pathfinder/PlayerPathfinder")]
public class PlayerPathfinder : Pathfinder
{
    [SerializeField] private VectorChannelSO vectorChannel;
    [SerializeField] private BoolChannelSO boolChannel;
    public override void Invoke(Vector3 from, Vector3 direction)
    {
        if (FindByRaycast(from, direction))
        {
            boolChannel.Invoke(true);
            vectorChannel.Invoke(direction);
        }
        else
        {
            boolChannel.Invoke(false);
        }
    }
}
