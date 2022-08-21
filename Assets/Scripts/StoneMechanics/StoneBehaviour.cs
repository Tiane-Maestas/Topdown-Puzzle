using UnityEngine;

namespace StoneTypes
{
    // Using the Strategy Pattern for different types of stones.
    public enum StoneType
    {
        Normal,
        Fire,
        Explosion,
        Bounce,
        Teleport,
        MindControl,
        Joker
    }

    public class StoneBehaviour
    {
        // For stone movement.
        protected Rigidbody2D _stoneBody;
        protected float _stoneSpeed = 10f;

        // For stone graphics.
        public string stoneTextureLocation;

        public StoneBehaviour(Rigidbody2D stoneBody)
        {
            stoneTextureLocation = "Stones/normal-stone";
            this._stoneBody = stoneBody;
        }

        public virtual void ThrowStone(Vector2 throwVector)
        {
            this._stoneBody.velocity = throwVector * this._stoneSpeed;
        }

        public virtual void OnCollisionEnter(Collision2D other)
        {

        }

        public virtual void Update()
        {

        }

        public virtual void FixedUpdate()
        {

        }

        public virtual void Destroy()
        {

        }
    }
}

// Developer Notes----
// Setting Sprite of the seperate stones can be done by loading a texture from a file. (using Nebula)
//      public Sprite sprite;
//      string FilePath = "F:\\GameProjects\\Topdown-Puzzle\\Assets\\Resources\\Stones\\yellow-stone.png";
//      float PixelsPerUnit = 16;
//      Texture2D SpriteTexture = Utils2D.LoadTextureFromFile(FilePath);
//      sprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);
//      Then In Active Stone you can set the sprite of the renderer like this.
//      this._sprite.sprite = this._stoneBehaviour.sprite;