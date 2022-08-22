using UnityEngine;

namespace StoneTypes
{
    public class ExplosionStone : StoneBehaviour
    {
        // Uses collider of this game object as a trigger.
        private GameObject _explosionArea;
        // Visiual effects from particle system.
        private GameObject _explosionVisuals;
        public ExplosionStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            stoneBody.gameObject.tag = StoneTags.Explosion;
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/explosion-stone";
            _explosionArea = (GameObject)Resources.Load("Prefabs/ExplosionArea", typeof(GameObject));
            _explosionVisuals = (GameObject)Resources.Load("Prefabs/Explosion", typeof(GameObject));
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
            GameObject explosionArea = GameObject.Instantiate(_explosionArea, this._stoneBody.transform.position, this._stoneBody.transform.rotation);
            GameObject.Destroy(explosionArea, 0.5f);
            GameObject explosionVisuals = GameObject.Instantiate(_explosionVisuals, this._stoneBody.transform.position, this._stoneBody.transform.rotation);
            GameObject.Destroy(explosionVisuals, 0.5f);
            base.Destroy();
        }
    }
}