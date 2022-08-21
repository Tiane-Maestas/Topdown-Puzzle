using UnityEngine;
using StoneTypes;

public class PlayerProjectileController : MonoBehaviour
{
    public GameObject genericStone;
    public StoneType currentStoneType;
    private bool _isShooting = false;

    private void Start()
    {
        // currentStoneType = StoneType.Normal;
    }

    private void Update()
    {
        _isShooting |= Input.GetMouseButtonDown(0);
    }

    private void FixedUpdate()
    {
        if (_isShooting)
        {
            if ((int)currentStoneType >= 6)
            {
                currentStoneType = StoneType.Normal;
            }
            ActiveStone.currentStoneBehaviour = currentStoneType;

            // aim with mouse
            Vector2 toMouseVector = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2) transform.position;
            toMouseVector.Normalize();
            ActiveStone.throwVector = toMouseVector;
            
            float throwAngle = Vector2.Angle(transform.up, toMouseVector);
            if (throwAngle <= 90)
            {
                // TODO magic number is a small distance to spawn stone away from player
                GameObject newStone = Instantiate(genericStone, (Vector2) this.transform.position + toMouseVector * 0.6f, this.transform.rotation);
            }
            currentStoneType++;
        }
        _isShooting = false;
    }
}
