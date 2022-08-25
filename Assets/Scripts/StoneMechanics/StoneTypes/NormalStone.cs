using UnityEngine;

namespace StoneTypes
{
    public class NormalStone : StoneBehaviour
    {
        public NormalStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            stoneBody.gameObject.tag = StoneTags.Normal;
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/normal-stone";
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
            SoundManager.PlaySound(SoundManager.Sound.StoneBreak, this._stoneBody.position, 1f);

            base.Destroy();
        }
    }
}