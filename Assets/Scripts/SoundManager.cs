using System.Collections.Generic;
using UnityEngine;

using StoneTypes;

public static class SoundManager
{
    public enum Sound 
    {
        Bounce,
        Explosion,
        Mindcontrol,
        Fire,
        StoneBreak,
        Teleport,
        Joker
    }

    private static Dictionary<Sound, float> soundTimerDictionary;

    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<Sound, float>();
        soundTimerDictionary[Sound.Mindcontrol] = 0f;
    }
    public static void PlaySound(Sound sound, Vector3 position, float volume = 1f)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();
            GameObject.Destroy(soundGameObject, audioSource.clip.length);
        }
    }

    public static void PlaySound(Sound sound, float volume=1f)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();
            GameObject.Destroy(soundGameObject, audioSource.clip.length);
        }
    }

    private static bool CanPlaySound(Sound sound)
    {
        switch (sound) 
        {
            default:
                return true;
            case Sound.Mindcontrol:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playerMoveTimerMax = 0.05f;
                    if (lastTimePlayed + playerMoveTimerMax < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else 
                {
                    return true;
                }
        }
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.instance.soundAudioClipArray)
        {
            if (sound == Sound.Joker)
            {
                // random audio for joker
                int randInt = Random.Range(0, JokerAudios.jokerAudioList.Count);
                return JokerAudios.jokerAudioList[randInt];

            }
            else if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }

    public static void Stop(Sound sound)
    {
        // TODO implement stop sound
    }
}
