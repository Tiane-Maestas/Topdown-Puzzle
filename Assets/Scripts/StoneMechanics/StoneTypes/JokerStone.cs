using System.Collections.Generic;
using UnityEngine;

namespace StoneTypes
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
    public class JokerStone : StoneBehaviour
    {

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
            SoundManager.PlaySound(SoundManager.Sound.Joker, this._stoneBody.position, 1f);

            base.Destroy();
        }
    }
}