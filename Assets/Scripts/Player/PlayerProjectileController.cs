using UnityEngine;
using StoneTypes;

public class PlayerProjectileController : MonoBehaviour
{
    public GameObject genericStone;
    public StoneType currentStoneType;
    private bool _isShooting = false;
    private bool _wasShooting = false;
    private float _throwOffset;
    private Animator _animator;

    private void Awake()
    {
        // Calculation so the stone doesn't collide with player initially.
        BoxCollider2D playerCollider = GetComponent<BoxCollider2D>();
        CircleCollider2D stoneCollider = genericStone.GetComponent<CircleCollider2D>();
        _throwOffset = Mathf.Abs(Mathf.Pow(playerCollider.bounds.max.x + stoneCollider.radius / 2, 2) + Mathf.Pow(playerCollider.bounds.max.x + stoneCollider.radius / 2, 2));

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isShooting = Input.GetMouseButton(0);
        Debug.Log(Input.GetMouseButton(0));
    }

    private void FixedUpdate()
    {
        // Animate if charging shot.
        if (_isShooting)
        {
            _wasShooting = true;
            _animator.SetBool("Idle", false);
            _animator.SetBool("Slinging", true);
        }
        else
        {
            _animator.SetBool("Idle", true);
            _animator.SetBool("Slinging", false);
        }

        // Shoot Stone on Release
        if (!_isShooting && _wasShooting)
        {
            // Aim with mouse
            Vector2 toMouseVector = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
            toMouseVector.Normalize();
            float throwAngle = Vector2.Angle(transform.up, toMouseVector);
            toMouseVector = (throwAngle <= 90) ? toMouseVector : -toMouseVector;

            // Shoot Stone
            ActiveStone.throwVector = toMouseVector;
            ActiveStone.currentStoneBehaviour = currentStoneType;
            GameObject newStone = Instantiate(genericStone, (Vector2)this.transform.position + toMouseVector * _throwOffset, this.transform.rotation);

            _wasShooting = false;
        }
    }
}
