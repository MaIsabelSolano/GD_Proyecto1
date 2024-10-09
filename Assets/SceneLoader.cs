using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadVictoryScene()
    {
        SceneManager.LoadScene("VictoryScene");
    }
}
