using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    public GameObject genericStone;
    private bool _isShooting = false;

    public int index = 0;

    private void Start()
    {

    }

    private void Update()
    {
        _isShooting |= Input.GetMouseButtonDown(0);
    }

    private void FixedUpdate()
    {
        if (_isShooting)
        {
            if (index >= 7)
            {
                index = 0;
            }
            ActiveStone.currentStoneBehaviour = index;
            index++;
            GameObject newStone = Instantiate(genericStone, this.transform.position, this.transform.rotation);
        }
        _isShooting = false;
    }
}
