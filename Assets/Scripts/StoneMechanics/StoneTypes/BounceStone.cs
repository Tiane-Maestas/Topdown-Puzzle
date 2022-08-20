using UnityEngine;

namespace StoneTypes
{
    public class BounceStone : StoneBehaviour
    {
        private static int _maxNumberOfBounces = 5;
        private int _currentNumberOfBounces = 0;
        private PhysicsMaterial2D _stoneMaterial;
        private CircleCollider2D _stoneCollider;
        public BounceStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            this._stoneSpeed = 10;
            this.stoneTextureLocation = "Stones/bounce-stone";
            // Create a bouncy material.
            this._stoneMaterial = new PhysicsMaterial2D("Bouncy");
            this._stoneMaterial.friction = stoneBody.sharedMaterial.friction;
            this._stoneMaterial.bounciness = 1;
            // Change material of stone to be bouncy.
            _stoneCollider = stoneBody.GetComponent<CircleCollider2D>();
            stoneBody.sharedMaterial = this._stoneMaterial;
            _stoneCollider.sharedMaterial = this._stoneMaterial;
        }

        public override void ThrowStone()
        {
            base.ThrowStone();
        }

        public override void OnCollisionEnter(Collision2D other)
        {
            _currentNumberOfBounces++;
            if (_currentNumberOfBounces >= _maxNumberOfBounces)
            {
                GameObject.Destroy(this._stoneBody.gameObject);
            }
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