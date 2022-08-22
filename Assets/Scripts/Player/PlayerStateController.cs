using UnityEngine;
using System.Linq;
using Nebula;
using StoneTypes;

public class PlayerStateController : MonoBehaviour
{
    private Rigidbody2D _playerBody;

    // All state machine vaiables.
    private GStateMachine _stateMachine;
    private GDelegateState _idleState;
    private GDelegateState _walkingState;
    private GDelegateState _slingingState;
    private GDelegateState _walkingSlingingState;

    private Animator _animator;

    private Vector2 _movement;

    private void Awake()
    {
        this._playerBody = GetComponent<Rigidbody2D>();
        this._animator = GetComponent<Animator>();

        // Initialize the player states w/ the state machine
        this._stateMachine = new GStateMachine();

        int[] idleAllowedTransitions = { 1, 2, 3 };
        _idleState = new GDelegateState(IdleStateCondition, null, null, null, null,
                                       0, "Idle", idleAllowedTransitions.ToList(), 0,
                                       _animator, "Idle");

        int[] walkingAllowedTransitions = { 0, 3 };
        _walkingState = new GDelegateState(WalkingStateCondition, WalkingStateAction,
                                          null, null, null,
                                          1, "Walking", walkingAllowedTransitions.ToList(), 1,
                                          _animator, "Walking");

        int[] slingingAllowedTransitions = { 0, 3 };
        _slingingState = new GDelegateState(SlingingStateCondition, null,
                                            null, LeaveSlingingState, null,
                                            2, "Slinging", slingingAllowedTransitions.ToList(), 2,
                                            _animator, "Slinging");

        int[] walkingSlingingAllowedTransitions = { 0, 1, 2 };
        _walkingSlingingState = new GDelegateState(WalkingSlingingStateCondition, WalkingSlingingStateAction,
                                                   null, LeaveWalkingSlingingState,
                                                   null, 3, "WalkingSlinging",
                                                   walkingSlingingAllowedTransitions.ToList(), 3,
                                                   _animator, "WalkingAndSlinging");

        this._stateMachine.SetIdleState(_idleState);
        this._stateMachine.AddState(_walkingState);
        this._stateMachine.AddState(_slingingState);
        this._stateMachine.AddState(_walkingSlingingState);

        ConfigureSlingingState();
    }

    private void Update()
    {
        // Note: the movement vector is handled here becuae it would have to be updated in every state.
        // IMPORTANT: The player input should always be checked first because the current frame behaviour
        // depends on that input. If it is checked last then you have to wait a whole new frame for the
        // input to effect the behvaiour on screen.
        UpdateMovementVector();
        this._stateMachine.UpdateState();
    }

    private void UpdateMovementVector()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement.Normalize();
    }

    private void FixedUpdate()
    {
        this._stateMachine.PerformStateAction();
    }

    #region Idle State Implementations

    private bool IdleStateCondition()
    {
        return true;
    }

    #endregion

    #region Walking State Implementations

    [Space]
    [Header("Walking State Parameters")]
    [SerializeField] private float _moveSpeed = 4f;
    private bool WalkingStateCondition()
    {
        return _movement != Vector2.zero;
    }

    private void WalkingStateAction()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        _playerBody.MovePosition(_playerBody.position + _movement * _moveSpeed * Time.fixedDeltaTime);
        _playerBody.rotation = Mathf.Atan2(_movement.y, _movement.x) * Mathf.Rad2Deg - 90f;
    }

    #endregion

    #region Slinging State Implementations

    [Space]
    [Header("Slinging State Parameters")]
    public GameObject genericStone;
    public StoneType currentStoneType;
    private float _throwOffset;
    private float _rightHandAngle;
    private void ConfigureSlingingState()
    {
        // Calculation so the stone doesn't collide with player initially.
        BoxCollider2D playerCollider = GetComponent<BoxCollider2D>();
        CircleCollider2D stoneCollider = genericStone.GetComponent<CircleCollider2D>();
        _throwOffset = Mathf.Abs(Mathf.Pow(playerCollider.bounds.max.x + stoneCollider.radius / 2, 2) + Mathf.Pow(playerCollider.bounds.max.x + stoneCollider.radius / 2, 2));

        // We always throw from the right hand. (Where the sling is)
        _rightHandAngle = Mathf.Atan(playerCollider.bounds.max.y / playerCollider.bounds.max.x);
    }
    private bool SlingingStateCondition()
    {
        return Input.GetMouseButton(0);
    }

    private void LeaveSlingingState()
    {
        if (!Input.GetMouseButton(0))
        {
            ThrowStone();
        }
    }

    private void ThrowStone()
    {
        // Aim with mouse
        Vector2 toMouseVector = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        toMouseVector.Normalize();
        float throwAngle = Vector2.Angle(transform.up, toMouseVector);
        toMouseVector = (throwAngle <= 90) ? toMouseVector : -toMouseVector;

        // Shoot Stone from Right Hand.
        Vector2 rightHand = transform.up;
        rightHand = Utils2D.RotateVector2ByRad(rightHand, _rightHandAngle);
        rightHand.Normalize();
        Debug.Log(rightHand);

        ActiveStone.throwVector = toMouseVector;
        ActiveStone.currentStoneBehaviour = currentStoneType;
        GameObject newStone = Instantiate(genericStone, (Vector2)this.transform.position + rightHand * _throwOffset, this.transform.rotation);
    }

    #endregion

    #region Walking and Slinging State Implementations

    private bool WalkingSlingingStateCondition()
    {
        return Input.GetMouseButton(0) && _movement != Vector2.zero;
    }

    private void WalkingSlingingStateAction()
    {
        PlayerMove();
    }

    private void LeaveWalkingSlingingState()
    {
        if (!Input.GetMouseButton(0))
        {
            ThrowStone();
        }
    }

    #endregion
}