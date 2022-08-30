using System.Collections.Generic;
using System;
using UnityEngine;

namespace Nebula
{
    public enum SoundType
    {
        None, // Functions like 'background' but has no specified sound type.
        Background, // Constant background sound to always play at a constant volume to player. (Ex. Background music)
        Ambient, // Enviornment sound that is dependent on player location and source location. (Ex. Fire)
        ConditionalBackground, // Same as 'background' but is frequently changed. (Ex. Player's own footsteps)
        ConditionalAmbient // Same as 'ambient' but will only play once. (Ex. Explosion)
    }
    public struct Sound
    {
        public string name;
        public SoundType type;
        public string fileLocation;
        public Sound(string name, SoundType type, string fileLocation)
        {
            this.name = name;
            this.type = type;
            this.fileLocation = fileLocation;
        }

        public override string ToString() => $"({name}, {type}, {fileLocation})";
    }
    public static class SoundManager
    {
        // This is a dictionary of all sounds with their names as keys. (Holds Information Only)
        private static Dictionary<string, Sound> sounds = new Dictionary<string, Sound>();
        // This is a dictionary between sound names and the game objects that play the audio.
        private static Dictionary<string, AudioSource> audioPlayers = new Dictionary<string, AudioSource>();

        private static Vector3 defaultSoundPosition = new Vector3(0, 0, 0);

        #region Data Handling
        public static void AddSound(string name, string fileLocation)
        {
            if (sounds.ContainsKey(name))
            {
                Debug.LogError("Couldn't Add Sound. Already Exists as " + sounds[name]);
                return;
            }
            sounds[name] = new Sound(name, SoundType.None, fileLocation);
            CreateAudioSource(name, defaultSoundPosition);
        }

        public static void AddSound(string name, SoundType type, string fileLocation)
        {
            if (sounds.ContainsKey(name))
            {
                Debug.LogError("Couldn't Add Sound. Already Exists as " + sounds[name]);
                return;
            }
            sounds[name] = new Sound(name, type, fileLocation);
            // Only create an audio source here if the sound is a background type.
            if (Array.Exists(backgroundSoundTypes, element => element == sounds[name].type))
            {
                CreateAudioSource(name, defaultSoundPosition);
            }
        }

        public static bool ContainsSound(string name)
        {
            return sounds.ContainsKey(name);
        }

        #endregion

        #region Background SoundTypes
        private static SoundType[] backgroundSoundTypes = { SoundType.None, SoundType.Background, SoundType.ConditionalBackground };

        // This method is only for background type sounds because they don't depend on a location.
        public static void PlaySound(string name, float volume = 1f)
        {
            // Can't play a sound that doesn't exist.
            if (!sounds.ContainsKey(name))
            {
                Debug.LogError($"Couldn't Play Sound. Doesn't Exists.  ({name})");
                return;
            }

            // Only play the sound if it is a supported sound type for this method.
            if (Array.Exists(backgroundSoundTypes, element => element == sounds[name].type))
            {
                // Any sound of this type will already have an audio source constructed.
                PlayAudioFromSource(name, volume);
                return; // Successful exit of method here.
            }
            Debug.LogError($"SoundType with given name ({name}) isn't supported by this play type. Try including a position.");
        }

        #endregion

        #region Ambient SoundTypes

        private static SoundType[] ambientSoundTypes = { SoundType.Ambient, SoundType.ConditionalAmbient };

        // This method is only for background type sounds because they don't depend on a location.
        public static void PlaySound(string name, Vector3 position, float volume = 1f)
        {
            // Can't play a sound that doesn't exist.
            if (!sounds.ContainsKey(name))
            {
                Debug.LogError($"Couldn't Play Sound. Doesn't Exists.  ({name})");
                return;
            }

            // Only play the sound if it is a supported sound type for this method.
            if (Array.Exists(ambientSoundTypes, element => element == sounds[name].type))
            {
                // Any sound of this type will need an audio source constructed.
                CreateAudioSource(name, position);
                PlayAudioFromSource(name, volume);

                return; // Successful exit of method here.
            }
            Debug.LogError($"SoundType with given name ({name}) isn't supported by this play type.");
        }

        #endregion

        public static void StopSound(string name)
        {
            // Can't stop a sound that doesn't exist.
            if (!sounds.ContainsKey(name))
            {
                Debug.LogError($"Couldn't Stop Sound. Doesn't Exists. ({name})");
                return;
            }

            if (!audioPlayers.ContainsKey(name))
            {
                Debug.LogError($"Couldn't Stop Sound. No Audio Player Exists. ({name})");
                return;
            }

            audioPlayers[name].Stop();
        }

        private static void PlayAudioFromSource(string name, float volume)
        {
            // All sounds will loop by default. 
            audioPlayers[name].volume = volume;
            audioPlayers[name].loop = true;
            audioPlayers[name].Play();

            // Handle edge case sound types.
            if (sounds[name].type == SoundType.ConditionalAmbient)
            {
                // Conditional Ambient sounds are destroyed after use because they vary too much.
                GameObject.Destroy(audioPlayers[name].gameObject, audioPlayers[name].clip.length);
                audioPlayers[name].loop = false;
                audioPlayers.Remove(name);
            }
        }

        private static void CreateAudioSource(string name, Vector3 position)
        {
            // Construct Game Object
            GameObject soundGameObject = new GameObject($"AudioSource: {name}");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(name);
            audioPlayers[name] = audioSource;
        }

        private static AudioClip GetAudioClip(string name)
        {
            return Resources.Load<AudioClip>(sounds[name].fileLocation);
        }
    }
}