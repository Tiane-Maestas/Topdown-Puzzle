using UnityEngine;

namespace StoneTypes
{
    public class NormalStone : StoneBehaviour
    {
        public NormalStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/normal-stone";
        }

        public override void ThrowStone()
        {
            base.ThrowStone();
        }

        public override void OnCollisionEnter(Collision2D other)
        {
            base.OnCollisionEnter(other);
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
            base.Destroy();
        }
    }
}