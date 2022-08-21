using UnityEngine;

namespace StoneTypes
{
    public class FireStone : StoneBehaviour
    {
        public FireStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/fire-stone";
        }

        public override void ThrowStone(Vector2 throwVector)
        {
            base.ThrowStone(throwVector);
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