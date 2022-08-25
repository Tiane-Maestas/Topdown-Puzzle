using System.Collections.Generic;
using UnityEngine;

namespace StoneTypes
{
    public class JokerStone : StoneBehaviour
    {
        public static class JokerAudios
        {
            public static List<AudioClip> jokerAudioList = new List<AudioClip>();

            static JokerAudios()
            {
                Object[] audioClips = Resources.LoadAll("Sound/joker");
                foreach (AudioClip audioClip in audioClips)
                {
                    jokerAudioList.Add(audioClip);
                }
            }
        }

        //TODO make static list in here0
        public JokerStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            stoneBody.gameObject.tag = StoneTags.Joker;
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/joker-stone";

        }

        public override void ThrowStone(Vector2 throwVector)
        {
            base.ThrowStone(throwVector);
        }

        public override void OnCollisionEnter(Collision2D other)
        {
            base.OnCollisionEnter(other);
        }

        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override void Destroy()
        {
            // random audio
            int randInt = Random.Range(0, JokerAudios.jokerAudioList.Count);
            AudioClip audio = JokerAudios.jokerAudioList[randInt];
            SoundManager.PlaySound(audio, 1f);

            base.Destroy();
        }
    }
}