using UnityEngine;

namespace StoneTypes
{
    public class TeleportStone : StoneBehaviour
    {
        public TeleportStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            stoneBody.gameObject.tag = StoneTags.Teleport;
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/teleport-stone";
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
            Vector2 stonePosition = this._stoneBody.position;
            GameObject _player = GameObject.FindWithTag("Player");
            _player.transform.SetPositionAndRotation(stonePosition, _player.transform.rotation);
            base.Destroy();
        }
    }
}