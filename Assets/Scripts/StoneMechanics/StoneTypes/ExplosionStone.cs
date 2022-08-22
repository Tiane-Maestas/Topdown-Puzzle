using UnityEngine;

namespace StoneTypes
{
    public class ExplosionStone : StoneBehaviour
    {
        private GameObject _debris;
        public ExplosionStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            stoneBody.gameObject.tag = StoneTags.Explosion;
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/explosion-stone";
            _debris = (GameObject)Resources.Load("Prefabs/Debris", typeof(GameObject));
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
            GameObject.Instantiate(_debris, this._stoneBody.transform.position, this._stoneBody.transform.rotation);
            // this._stoneBody.transform.position
            base.Destroy();
        }
    }
}