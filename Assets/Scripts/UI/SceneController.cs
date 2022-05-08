using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(fileName = "SceneController")]
public class SceneController : ScriptableObject
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
