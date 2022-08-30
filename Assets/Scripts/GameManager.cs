using UnityEngine;
using Nebula;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        ConfigureSoundManager();
    }

    private void ConfigureSoundManager()
    {
        // Add any sound that will be used later here.
        SoundManager.AddSound("Fire", SoundType.Ambient, "sounds/minecraft_fire"); // Add the AudioSource here maybe.
    }
}