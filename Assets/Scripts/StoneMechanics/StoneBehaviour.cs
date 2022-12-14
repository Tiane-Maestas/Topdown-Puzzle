using UnityEngine;
using Nebula;

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

    public static class StoneTags
    {
        public static string Normal = "Stone";
        public static string Fire = "Fire-Stone";
        public static string Explosion = "Explosion-Stone";
        public static string Bounce = "Bounce-Stone";
        public static string Teleport = "Teleport-Stone";
        public static string MindControl = "Mind-Control-Stone";
        public static string Joker = "Joker-Stone";
    }

    public class StoneBehaviour
    {
        // For stone movement.
        protected Rigidbody2D _stoneBody;
        protected float _stoneSpeed = 10f;

        // For stone graphics.
        public string stoneTextureLocation;
        private GameObject _breakVisuals;
        private float _breakTimeDuration = 0.25f;

        public StoneBehaviour(Rigidbody2D stoneBody)
        {
            stoneTextureLocation = "Stones/normal-stone";
            this._stoneBody = stoneBody;
            _breakVisuals = (GameObject)Resources.Load("Prefabs/BreakStone", typeof(GameObject));
            _breakTimeDuration = _breakVisuals.GetComponent<ParticleSystem>().main.duration;
        }

        public virtual void ThrowStone(Vector2 throwVector)
        {
            SoundManager.PlaySound("ThrowStone", 0.1f);
            this._stoneBody.velocity = throwVector * this._stoneSpeed;
        }

        public virtual void OnCollisionEnter(Collision2D other)
        {
            GameObject.Destroy(this._stoneBody.gameObject);
        }

        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Button"))
            {
                GameObject.Destroy(this._stoneBody.gameObject);
            }
        }

        public virtual void Update()
        {

        }

        public virtual void FixedUpdate()
        {

        }

        public virtual void Destroy()
        {
            SoundManager.PlaySound("BreakStone", this._stoneBody.transform.position, 0.5f);
            GameObject breakVisuals = GameObject.Instantiate(_breakVisuals, this._stoneBody.transform.position, this._stoneBody.transform.rotation);
            GameObject.Destroy(breakVisuals, _breakTimeDuration);
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