using UnityEngine;
using UnityEngine.EventSystems;
public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Pathfinder pathfinder;
    [SerializeField] private Transform fromTransform;
    [SerializeField] private LayerMask layerMask;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (fromTransform != null)
        {
            GetPoint();
        }
        else
        {
            fromTransform = FindObjectOfType<PlayerController>().transform;
        }
    }
    private void GetPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, layerMask))
        {
            pathfinder.Invoke(fromTransform.position, raycastHit.point);
        }
    }
}
