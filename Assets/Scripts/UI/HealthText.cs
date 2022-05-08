using UnityEngine;
public class HealthText : ResourceText
{
    [SerializeField] private PlayerInfoSO playerInfo;
    private void Start()
    {
        _count = playerInfo.Health;
        text.text = _count.ToString();
    }
    protected override void ChangeValue(int count)
    {
        _count += count;
        _count = Mathf.Clamp(_count, 0, playerInfo.Health);
        text.text = _count.ToString();
    }
}