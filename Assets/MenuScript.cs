using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class MenuScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Button playButton;
    private void Start()
    {
        playButton.onClick.AddListener(() => StartCoroutine(nameof(LoadAsynchronously)));
    }
    private IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}