using UnityEngine;
using Nebula;

namespace StoneTypes
{
    public class TeleportStone : StoneBehaviour
    {
        private bool _inTunnel = false;
        private float _tunnelRayLength = 0.3f;
        private bool _againstHole = false;
        public int holeLayer = 8;
        public TeleportStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            stoneBody.gameObject.tag = StoneTags.Teleport;
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/teleport-stone";
            Stats.TeleportStonesThrown++;
        }

        public override void ThrowStone(Vector2 throwVector)
        {
            base.ThrowStone(throwVector);
        }

        public override void OnCollisionEnter(Collision2D other)
        {
            if (!_inTunnel && !_againstHole)
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
            Vector2 upRightCheck = Utils2D.RotateVector2ByDeg(this._stoneBody.gameObject.transform.right, 15);
            RaycastHit2D[] upRightHit = Physics2D.RaycastAll(this._stoneBody.gameObject.transform.position, upRightCheck, _tunnelRayLength);
            Debug.DrawRay(this._stoneBody.gameObject.transform.position, upRightCheck * _tunnelRayLength, Color.green);
            Vector2 upLeftCheck = Utils2D.RotateVector2ByDeg(-this._stoneBody.gameObject.transform.right, -15);
            RaycastHit2D[] upLeftHit = Physics2D.RaycastAll(this._stoneBody.gameObject.transform.position, upLeftCheck, _tunnelRayLength);
            Debug.DrawRay(this._stoneBody.gameObject.transform.position, upLeftCheck * _tunnelRayLength, Color.green);

            Vector2 backRightCheck = Utils2D.RotateVector2ByDeg(this._stoneBody.gameObject.transform.right, -20);
            RaycastHit2D[] backRightHit = Physics2D.RaycastAll(this._stoneBody.gameObject.transform.position, backRightCheck, _tunnelRayLength);
            Debug.DrawRay(this._stoneBody.gameObject.transform.position, backRightCheck * _tunnelRayLength, Color.green);
            Vector2 backLeftCheck = Utils2D.RotateVector2ByDeg(-this._stoneBody.gameObject.transform.right, 20);
            RaycastHit2D[] backLeftHit = Physics2D.RaycastAll(this._stoneBody.gameObject.transform.position, backLeftCheck, _tunnelRayLength);
            Debug.DrawRay(this._stoneBody.gameObject.transform.position, backLeftCheck * _tunnelRayLength, Color.green);

            if ((upRightHit.Length > 1 && upRightHit[upRightHit.Length - 1].collider.tag == "Enviornment") &&
                (upLeftHit.Length > 1 && upLeftHit[upLeftHit.Length - 1].collider.tag == "Enviornment") ||
                (backRightHit.Length > 1 && backRightHit[backRightHit.Length - 1].collider.tag == "Enviornment") &&
                (backLeftHit.Length > 1 && backLeftHit[backLeftHit.Length - 1].collider.tag == "Enviornment"))
            {
                _inTunnel = true;
            }
            else
            {
                _inTunnel = false;
            }

            // Check for holes.
            _againstHole = false;

            Vector2 forwardCheck = this._stoneBody.gameObject.transform.up;
            RaycastHit2D[] forwardHit = Physics2D.RaycastAll(this._stoneBody.gameObject.transform.position, forwardCheck, _tunnelRayLength);
            Debug.DrawRay(this._stoneBody.gameObject.transform.position, forwardCheck * _tunnelRayLength, Color.red);
            Vector2 backCheck = -this._stoneBody.gameObject.transform.up;
            RaycastHit2D[] backHit = Physics2D.RaycastAll(this._stoneBody.gameObject.transform.position, backCheck, _tunnelRayLength);
            Debug.DrawRay(this._stoneBody.gameObject.transform.position, backCheck * _tunnelRayLength, Color.green);

            foreach (RaycastHit2D hit in forwardHit)
            {
                _againstHole = _againstHole || (hit.collider.gameObject.layer.CompareTo(holeLayer) == 0);
            }
            foreach (RaycastHit2D hit in backHit)
            {
                _againstHole = _againstHole || (hit.collider.gameObject.layer.CompareTo(holeLayer) == 0);
            }
            foreach (RaycastHit2D hit in upRightHit)
            {
                _againstHole = _againstHole || (hit.collider.gameObject.layer.CompareTo(holeLayer) == 0);
            }
            foreach (RaycastHit2D hit in upLeftHit)
            {
                _againstHole = _againstHole || (hit.collider.gameObject.layer.CompareTo(holeLayer) == 0);
            }
            foreach (RaycastHit2D hit in backRightHit)
            {
                _againstHole = _againstHole || (hit.collider.gameObject.layer.CompareTo(holeLayer) == 0);
            }
            foreach (RaycastHit2D hit in backLeftHit)
            {
                _againstHole = _againstHole || (hit.collider.gameObject.layer.CompareTo(holeLayer) == 0);
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

            SoundManager.PlaySound("Teleport", this._stoneBody.transform.position, 0.5f);

            base.Destroy();
        }
    }
}