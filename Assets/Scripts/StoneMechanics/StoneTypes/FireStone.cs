using UnityEngine;

namespace StoneTypes
{
    public class FireStone : StoneBehaviour
    {
        // Visiual effects from particle system.
        private GameObject _fireVisuals;
        private float _fireTimeDuration = 3f;
        private GameObject _fireTrail;
        public FireStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            stoneBody.gameObject.tag = StoneTags.Fire;
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/fire-stone";
            _fireVisuals = (GameObject)Resources.Load("Prefabs/Fire", typeof(GameObject));
            _fireTimeDuration = _fireVisuals.GetComponent<ParticleSystem>().main.duration;
            // Instantiate trail renderer and parent it to the stone body.
            _fireTrail = (GameObject)Resources.Load("Prefabs/FireTrail", typeof(GameObject));
            GameObject.Instantiate(_fireTrail, stoneBody.transform.position, stoneBody.transform.rotation).transform.SetParent(stoneBody.transform);
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
            GameObject fireVisuals = GameObject.Instantiate(_fireVisuals, this._stoneBody.transform.position, this._stoneBody.transform.rotation);
            GameObject.Destroy(fireVisuals, _fireTimeDuration);
            base.Destroy();
        }
    }
}