using UnityEngine;

namespace StoneTypes
{
    public class ExplosionStone : StoneBehaviour
    {
        // Uses collider of this game object as a trigger.
        private GameObject _explosionArea;
        // Visiual effects from particle system.
        private GameObject _explosionVisuals;
        private float _explosionTimeDuration = 0.5f;
        public ExplosionStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            stoneBody.gameObject.tag = StoneTags.Explosion;
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/explosion-stone";
            _explosionArea = (GameObject)Resources.Load("Prefabs/ExplosionArea", typeof(GameObject));
            _explosionVisuals = (GameObject)Resources.Load("Prefabs/Explosion", typeof(GameObject));
            _explosionTimeDuration = _explosionVisuals.GetComponent<ParticleSystem>().main.duration;
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
            GameObject explosionArea = GameObject.Instantiate(_explosionArea, this._stoneBody.transform.position, this._stoneBody.transform.rotation);
            GameObject.Destroy(explosionArea, _explosionTimeDuration);
            GameObject explosionVisuals = GameObject.Instantiate(_explosionVisuals, this._stoneBody.transform.position, this._stoneBody.transform.rotation);
            GameObject.Destroy(explosionVisuals, _explosionTimeDuration);

            SoundManager.PlaySound(SoundManager.Sound.Explosion, this._stoneBody.position, 0.6f);
            base.Destroy();
        }
    }
}