using TMPro;
using UnityEngine;
public class CrystalText : ResourceText
{
    [SerializeField] private PlayerInfoSO OnPlayerDead;
    [SerializeField] private TextMeshProUGUI RecordText;
    private int record;
    private void Start()
    {
        OnPlayerDead.AddListener(SaveCount);
    }
    private void SaveCount()
    {
        record = PlayerPrefs.GetInt("Crystals", 0);
        if (count > record)
        {
            record = count;
            PlayerPrefs.SetInt("Crystals", count);
        }
        RecordText.text = "Best :" + record;
    }
    private void OnDestroy()
    {
        OnPlayerDead.RemoveListener(SaveCount);
    }
}
