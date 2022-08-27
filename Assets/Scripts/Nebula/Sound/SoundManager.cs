using System.Collections.Generic;
using UnityEngine;

namespace Nebula
{
    public enum SoundType
    {
        None,
        Background, // Constant background sound to always play at a constant volume to player. (Ex. Background music)
        Ambient, // Enviornment sound that is dependent on player location and source location. (Ex. Fire)
        ConditionalBackground // Same as 'background' but is frequently changed. (Ex. Player's own footsteps)
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
        // This is a dictionary of all sounds with their names as keys.
        private static Dictionary<string, Sound> sounds;

        public static void AddSound(string name, string fileLocation)
        {
            if (sounds.ContainsKey(name))
            {
                Debug.LogError("Couldn't Add Sound. Already Exists as " + sounds[name]);
                return;
            }
            sounds[name] = new Sound(name, SoundType.None, fileLocation);
        }

        public static void AddSound(string name, SoundType type, string fileLocation)
        {
            if (sounds.ContainsKey(name))
            {
                Debug.LogError("Couldn't Add Sound. Already Exists as " + sounds[name]);
                return;
            }
            sounds[name] = new Sound(name, type, fileLocation);
        }

    }
}