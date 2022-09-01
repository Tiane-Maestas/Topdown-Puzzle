using UnityEngine;
using Nebula;
using StoneTypes;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string endTime = "";
    private GUIManager gui;
    private void Awake()
    {
        ConfigureSounds();

        // This doesn't allow the player to walk over holes but allows stones to be thrown over holes.
        Physics2D.IgnoreLayerCollision(7, 8, true);

        SoundManager.PlaySound("BackgroundMusic", 0.1f);

        gui = GetComponent<GUIManager>();
    }

    private void ConfigureSounds()
    {
        // Add any sound that will be used later here.
        SoundManager.AddSound("BackgroundMusic", SoundType.Background, "sounds/Exploring the Depths");
        SoundManager.AddSound("Walk", SoundType.Background, "sounds/Walk");
        SoundManager.ChangeAudioPitch("Walk", 1.75f);
        SoundManager.AddSound("ThrowStone", SoundType.ConditionalBackground, "sounds/stone_shot");
        SoundManager.AddSound("DoorOpen", SoundType.ConditionalBackground, "sounds/Enter");
        SoundManager.AddSound("Coin", SoundType.ConditionalBackground, "sounds/coin");
        SoundManager.AddSound("Button", SoundType.ConditionalAmbient, "sounds/Button", 8);
        SoundManager.AddSound("Fire", SoundType.Ambient, "sounds/constant_fire", 4);
        SoundManager.AddSound("BreakStone", SoundType.ConditionalAmbient, "sounds/minecraft_stone", 8);
        SoundManager.AddSound("Bounce", SoundType.ConditionalAmbient, "sounds/stone_bounce", 8);
        SoundManager.AddSound("Explosion", SoundType.ConditionalAmbient, "sounds/explosion", 8);
        SoundManager.AddSound("FireStone", SoundType.ConditionalAmbient, "sounds/minecraft_fire", 8);
        SoundManager.AddSound("MindControlStone", SoundType.Ambient, "sounds/mindcontrol", 8);
        SoundManager.AddSound("Teleport", SoundType.ConditionalAmbient, "sounds/teleport", 8);
        // Sounds from joker folder.
        Object[] jokerAudioClips = Resources.LoadAll("sounds/joker");
        JokerStone.numJokerAudios = jokerAudioClips.Length;
        for (int i = 0; i < jokerAudioClips.Length; i++)
        {
            SoundManager.AddSound($"Joker{i}", SoundType.ConditionalAmbient, $"sounds/joker/{jokerAudioClips[i].name}", 8);
        }
    }

    private void Update()
    {
        // Handle End Game
        if (gui.coinText.text.Equals("10"))
        {
            endTime = gui.currentTime;
            SoundManager.StopSound("BackgroundMusic");
            SceneManager.LoadScene("MenuScene");
        }
    }
}