using UnityEngine;
using Nebula;

namespace StoneTypes
{
    public class BounceStone : StoneBehaviour
    {
        private static int _maxNumberOfBounces = 1;
        private int _currentNumberOfBounces = 0;
        private PhysicsMaterial2D _stoneMaterial;
        private CircleCollider2D _stoneCollider;
        public BounceStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            stoneBody.gameObject.tag = StoneTags.Bounce;
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/bounce-stone";
            // Create a bouncy material.
            this._stoneMaterial = new PhysicsMaterial2D("Bouncy");
            this._stoneMaterial.friction = stoneBody.sharedMaterial.friction;
            this._stoneMaterial.bounciness = 1;
            // Change material of stone to be bouncy.
            _stoneCollider = stoneBody.GetComponent<CircleCollider2D>();
            stoneBody.sharedMaterial = this._stoneMaterial;
            _stoneCollider.sharedMaterial = this._stoneMaterial;
            Stats.BounceStonesThrown++;
        }

        public override void ThrowStone(Vector2 throwVector)
        {
            base.ThrowStone(throwVector);
        }

        public override void OnCollisionEnter(Collision2D other)
        {

            if (_currentNumberOfBounces >= _maxNumberOfBounces)
            {
                GameObject.Destroy(this._stoneBody.gameObject);
            }
            else
            {
                SoundManager.PlaySound("Bounce", this._stoneBody.position, 0.5f);
            }
            _currentNumberOfBounces++;
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
            base.Destroy();
        }
    }
}