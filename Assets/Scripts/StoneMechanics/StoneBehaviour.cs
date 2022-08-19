using UnityEngine;

public class StoneBehaviour
{
    // For stone movement.
    protected Rigidbody2D _stoneBody;
    protected float _stoneSpeed = 10f;

    // For stone graphics.
    public string stoneTextureLocation;

    public StoneBehaviour()
    {
        stoneTextureLocation = "Stones/normal-stone";
    }

    public virtual void ThrowStone(Rigidbody2D stoneBody)
    {
        this._stoneBody = stoneBody;
        this._stoneBody.velocity = _stoneBody.transform.up * this._stoneSpeed;
    }

    public virtual void OnCollisionEnter(Collision collision)
    {

    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {

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