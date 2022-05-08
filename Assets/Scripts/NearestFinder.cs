using UnityEngine;
using System.Linq;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Finder")]
public class NearestFinder : ScriptableObject
{
    public T FindNearest<T>(Transform transform) where T : MonoBehaviour
    {
        IEnumerable<T> sequence = FindObjectsOfType<T>();
        return sequence.Aggregate((x, y)
            => (x.transform.position - transform.position).sqrMagnitude < (y.transform.position - transform.position).sqrMagnitude ? x : y);
    }
}
