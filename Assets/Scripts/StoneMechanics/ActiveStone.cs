using UnityEngine;
using System;
using StoneTypes;

public class ActiveStone : MonoBehaviour
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

    // Gives the ability to set the type of stone to instantiate as static class variables.
    public static int currentStoneBehaviour = (int)StoneType.Normal;
    public static StoneBehaviour[] allStoneBehaviours = new StoneBehaviour[Enum.GetNames(typeof(StoneType)).Length];
    private static bool _stoneBehavioursSet = false;

    // Specific to each individual class instance.
    private StoneBehaviour _stoneBehaviour;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _stoneBody;

    private void Awake()
    {
        // Grab the needed components.
        this._spriteRenderer = GetComponent<SpriteRenderer>();
        this._stoneBody = GetComponent<Rigidbody2D>();
        // Setup the behaviour for this active stone.
        SetupStoneBehavious();
        this._stoneBehaviour = ActiveStone.allStoneBehaviours[ActiveStone.currentStoneBehaviour];
        // Set the texture of this active stone based off of the stone behaviour.
        this._spriteRenderer.sprite = (Sprite)Resources.Load(this._stoneBehaviour.stoneTextureLocation, typeof(Sprite));
    }

    private void SetupStoneBehavious()
    {
        // Only set all the stone behaviours the first time they are needed.
        if (!ActiveStone._stoneBehavioursSet)
        {
            ActiveStone.allStoneBehaviours[(int)StoneType.Normal] = new NormalStone();
            ActiveStone.allStoneBehaviours[(int)StoneType.Fire] = new FireStone();
            ActiveStone.allStoneBehaviours[(int)StoneType.Explosion] = new ExplosionStone();
            ActiveStone.allStoneBehaviours[(int)StoneType.Bounce] = new BounceStone();
            ActiveStone.allStoneBehaviours[(int)StoneType.Teleport] = new TeleportStone();
            ActiveStone.allStoneBehaviours[(int)StoneType.MindControl] = new MindControlStone();
            ActiveStone.allStoneBehaviours[(int)StoneType.Joker] = new JokerStone();
            ActiveStone._stoneBehavioursSet = true;
            Debug.Log("Stone Behaviours Setup Complete.");
        }
    }

    private void Start()
    {
        this._stoneBehaviour.ThrowStone(this._stoneBody);
    }

    private void Update()
    {
        this._stoneBehaviour.Update();
    }

    private void FixedUpdate()
    {
        this._stoneBehaviour.FixedUpdate();
    }
}
