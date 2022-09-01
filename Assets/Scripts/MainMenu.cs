using UnityEngine;
using UnityEngine.SceneManagement;
using Nebula;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Demo");
        // One of these sounds won't exist to stop depending on what loop we're on.
        SoundManager.StopSound("MenuMusic");
        SoundManager.StopSound("WinMusic");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
