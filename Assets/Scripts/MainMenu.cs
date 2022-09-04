using UnityEngine;
using UnityEngine.SceneManagement;
using Nebula;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // One of these sounds won't exist to stop depending on what loop we're on.
        SoundManager.StopSound("MenuMusic");
        SoundManager.StopSound("WinMusic");
        SoundManager.ClearAudioPlayersAndSounds();
        SceneManager.LoadScene("Demo");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
