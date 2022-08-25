using UnityEngine;
using Nebula;

namespace StoneTypes
{
    public class TeleportStone : StoneBehaviour
    {
        private bool _inTunnel = false;
        private float _tunnelRayLength = 0.3f;
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
            if (!_inTunnel)
            {
                base.OnCollisionEnter(other);
            }
        }

        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
        }

        public override void Update()
        {
            // Ray Cast to either side of the stone to check if it's in a tunnel.
            Vector2 rightCheck = Utils2D.RotateVector2ByDeg(this._stoneBody.gameObject.transform.right, 15);
            RaycastHit2D[] rightHit = Physics2D.RaycastAll(this._stoneBody.gameObject.transform.position, rightCheck, _tunnelRayLength);
            Debug.DrawRay(this._stoneBody.gameObject.transform.position, rightCheck * _tunnelRayLength, Color.green);
            Vector2 leftCheck = Utils2D.RotateVector2ByDeg(-this._stoneBody.gameObject.transform.right, -15);
            RaycastHit2D[] leftHit = Physics2D.RaycastAll(this._stoneBody.gameObject.transform.position, leftCheck, _tunnelRayLength);
            Debug.DrawRay(this._stoneBody.gameObject.transform.position, leftCheck * _tunnelRayLength, Color.green);

            if ((rightHit.Length > 1 && rightHit[rightHit.Length - 1].collider.tag == "Enviornment") &&
                (leftHit.Length > 1 && leftHit[leftHit.Length - 1].collider.tag == "Enviornment"))
            {
                _inTunnel = true;
            }
            else
            {
                _inTunnel = false;
            }
            base.Update();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override void Destroy()
        {
            if (_inTunnel)
            {
                return;
            }
            GameObject _player = GameObject.FindWithTag("Player");
            _player.transform.SetPositionAndRotation(this._stoneBody.transform.position, _player.transform.rotation);
            base.Destroy();

            SoundManager.PlaySound(SoundManager.Sound.Teleport, 0.7f);
        }
    }
}