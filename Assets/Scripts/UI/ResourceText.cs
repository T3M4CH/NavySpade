using TMPro;
using UnityEngine;
public class ResourceText : MonoBehaviour
{
    [SerializeField] private IntChannelSO OnChangeValue;
    [SerializeField] protected TextMeshProUGUI text;
    [SerializeField] protected int _count;
    public int count => _count;
    private void Awake()
    {
        text.text = _count.ToString();
        OnChangeValue.AddListener(ChangeValue);
    }
    protected virtual void ChangeValue(int count)
    {
        _count += count;
        text.text = _count.ToString();
    }
}
