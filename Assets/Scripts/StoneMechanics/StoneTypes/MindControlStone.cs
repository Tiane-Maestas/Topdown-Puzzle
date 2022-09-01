using UnityEngine;
using Nebula;

namespace StoneTypes
{
    public class MindControlStone : StoneBehaviour
    {
        private Vector2 _towardsMouse;
        private float _controlDelay = 0.25f;
        private float _startTime;
        private float _minDistance = 0.25f;

        private string _soundName;

        public MindControlStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            stoneBody.gameObject.tag = StoneTags.MindControl;
            this._stoneSpeed = 7.5f;
            this.stoneTextureLocation = "Stones/mind-control-stone";
            this._startTime = Time.time;
            Stats.MindStonesThrown++;
        }

        public override void ThrowStone(Vector2 throwVector)
        {
            _soundName = SoundManager.PlaySound("MindControlStone", this._stoneBody.transform.position, 0.6f);
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
            // If hit mouse destroy.
            if (Vector2.Distance((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), this._stoneBody.position) <= _minDistance)
            {
                GameObject.Destroy(this._stoneBody.gameObject);
                return;
            }

            this._towardsMouse = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - this._stoneBody.position;
            this._towardsMouse.Normalize();

            SoundManager.UpdateAudioSourceLocation(_soundName, this._stoneBody.transform.position);

            base.Update();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            // Move towards mouse
            if (Time.time - this._startTime >= _controlDelay)
            {
                this._stoneBody.velocity = this._towardsMouse * this._stoneSpeed;
            }
        }

        public override void Destroy()
        {
            SoundManager.StopSoundAndDestroyAudioPlayer(_soundName);
            base.Destroy();
        }
    }
}