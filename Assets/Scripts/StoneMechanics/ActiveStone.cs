using UnityEngine;
using StoneTypes;

public class ActiveStone : MonoBehaviour
{
    private float _stoneDestroyDelay = 10f;

    // Gives the ability to set the current type of stone from a static StoneType.
    public static StoneType currentStoneBehaviour = StoneType.Normal;
    public static Vector2 throwVector;

    // Specific to each individual class instance.
    private StoneBehaviour _stoneBehaviour;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _stoneBody;

    private void Awake()
    {
        // Grab the needed components.
        this._spriteRenderer = GetComponent<SpriteRenderer>();
        this._stoneBody = GetComponent<Rigidbody2D>();
        // Set the behaviour for this active stone using the strategy pattern.
        this._stoneBehaviour = GetStoneBehaviour(ActiveStone.currentStoneBehaviour);
        // Set the texture of this active stone based off of the stone behaviour.
        this._spriteRenderer.sprite = (Sprite)Resources.Load(this._stoneBehaviour.stoneTextureLocation, typeof(Sprite));
    }

    private StoneBehaviour GetStoneBehaviour(StoneType stoneType)
    {
        switch (stoneType)
        {
            case StoneType.Normal:
                return new NormalStone(this._stoneBody);
            case StoneType.Fire:
                return new FireStone(this._stoneBody);
            case StoneType.Explosion:
                return new ExplosionStone(this._stoneBody);
            case StoneType.Bounce:
                return new BounceStone(this._stoneBody);
            case StoneType.Teleport:
                return new TeleportStone(this._stoneBody);
            case StoneType.MindControl:
                return new MindControlStone(this._stoneBody);
            case StoneType.Joker:
                return new JokerStone(this._stoneBody);
            default:
                return new StoneBehaviour(this._stoneBody);
        }
    }

    private void Start()
    {
        this._stoneBehaviour.ThrowStone(throwVector);
        // (Not really necessary and caused bugs with teleport.)
        // Destroy(this.gameObject, _stoneDestroyDelay); 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        this._stoneBehaviour.OnCollisionEnter(other);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this._stoneBehaviour.OnTriggerEnter2D(other);
    }

    private void Update()
    {
        this._stoneBehaviour.Update();
    }

    private void FixedUpdate()
    {
        this._stoneBehaviour.FixedUpdate();
    }

    private void OnDestroy()
    {
        this._stoneBehaviour.Destroy();
    }
}
