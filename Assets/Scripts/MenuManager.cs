using UnityEngine;
using TMPro;
using Nebula;

public class MenuManager : MonoBehaviour
{
    public GameObject gameStats;
    public TMP_Text time;
    public TMP_Text normal;
    public TMP_Text fire;
    public TMP_Text explosion;
    public TMP_Text bounce;
    public TMP_Text teleport;
    public TMP_Text mind;
    public TMP_Text joker;
    private void Awake()
    {
        if (GameManager.endTime.Length > 0)
        {
            DisplayGameStats();
            SoundManager.AddSound("WinMusic", SoundType.Background, "sounds/Feel-Good Victory");
            SoundManager.PlaySound("WinMusic", 0.5f);
        }
        else
        {
            // Start Menu Music
            SoundManager.AddSound("MenuMusic", SoundType.Background, "sounds/New Destinations");
            SoundManager.PlaySound("MenuMusic", 0.5f);
        }
    }
    private void DisplayGameStats()
    {
        time.text = time.text + GameManager.endTime;
        normal.text = normal.text + Stats.NormalStonesThrown.ToString();
        fire.text = fire.text + Stats.FireStonesThrown.ToString();
        explosion.text = explosion.text + Stats.ExplosionStonesThrown.ToString();
        bounce.text = bounce.text + Stats.BounceStonesThrown.ToString();
        teleport.text = teleport.text + Stats.TeleportStonesThrown.ToString();
        mind.text = mind.text + Stats.MindStonesThrown.ToString();
        joker.text = joker.text + Stats.JokerStonesThrown.ToString();
        gameStats.SetActive(true);
    }
}
