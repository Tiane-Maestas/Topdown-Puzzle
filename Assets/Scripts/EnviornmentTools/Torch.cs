using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private bool _onFire = false;
    private GameObject _fireVisuals;

    private void Start()
    {
        _fireVisuals = (GameObject)Resources.Load("Prefabs/TorchFire", typeof(GameObject));
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fire-Stone")
        {
            LightTorch();
        }
    }

    private void LightTorch()
    {
        if (!_onFire)
        {
            Vector3 firePosition = new Vector3(this.transform.position.x, this.transform.position.y, -1);
            GameObject fireVisuals = GameObject.Instantiate(_fireVisuals, firePosition, this.transform.rotation);
        }
        _onFire = true;
    }
}
