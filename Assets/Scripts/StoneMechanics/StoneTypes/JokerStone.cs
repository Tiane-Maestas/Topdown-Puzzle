using UnityEngine;
using Nebula;

namespace StoneTypes
{
    public class JokerStone : StoneBehaviour
    {

        public static int numJokerAudios = 0;
        private string _audio;
        public JokerStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            stoneBody.gameObject.tag = StoneTags.Joker;
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/joker-stone";
            this._audio = $"Joker{Random.Range(0, JokerStone.numJokerAudios)}";
            Stats.JokerStonesThrown++;
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
            SoundManager.PlaySound(this._audio, this._stoneBody.position, 0.6f);
            base.Destroy();
        }
    }
}