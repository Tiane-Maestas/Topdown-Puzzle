using UnityEngine;
using StoneTypes;

public class PlayerProjectileController : MonoBehaviour
{
    public GameObject genericStone;
    public StoneType currentStoneType;
    private bool _isShooting = false;

    private void Start()
    {
        currentStoneType = StoneType.Normal;
    }

    private void Update()
    {
        _isShooting |= Input.GetMouseButtonDown(0);
    }

    private void FixedUpdate()
    {
        if (_isShooting)
        {
            if ((int)currentStoneType >= 7)
            {
                currentStoneType = StoneType.Normal;
            }
            ActiveStone.currentStoneBehaviour = currentStoneType;
            GameObject newStone = Instantiate(genericStone, this.transform.position, this.transform.rotation);
            currentStoneType++;
        }
        _isShooting = false;
    }
}
