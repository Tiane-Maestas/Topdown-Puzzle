using UnityEngine;

namespace StoneTypes
{
    public class MindControlStone : StoneBehaviour
    {
        private Vector2 mousePosition;
        
        [SerializeField]
        private float controlDelay = 0.5f;

        public MindControlStone(Rigidbody2D stoneBody) : base(stoneBody)
        {
            stoneBody.gameObject.tag = StoneTags.MindControl;
            this._stoneSpeed = 10f;
            this.stoneTextureLocation = "Stones/mind-control-stone";
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
            this.mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            // move towards mouse
            this._stoneBody.position = Vector2.Lerp(this._stoneBody.position, this.mousePosition, Time.fixedDeltaTime * 5);
        }

        public override void Destroy()
        {
            base.Destroy();
        }
    }
}