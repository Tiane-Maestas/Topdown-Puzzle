using UnityEngine;

namespace StoneTypes
{
    public class NormalStone : StoneBehaviour
    {
        public NormalStone() : base()
        {
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/normal-stone";
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