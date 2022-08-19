using UnityEngine;

namespace StoneTypes
{
    public class BounceStone : StoneBehaviour
    {
        public BounceStone() : base()
        {
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/bounce-stone";
        }

        public override void ThrowStone(Rigidbody2D stoneBody)
        {
            base.ThrowStone(stoneBody);
        }

        public override void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}