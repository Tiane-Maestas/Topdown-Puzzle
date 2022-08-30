using UnityEngine;
using UnityEngine.Events;
using Nebula;

public class Torch : MonoBehaviour
{
    // Should the doors that are listening open or close?
    public UnityEvent openEvent;

    private bool _onFire = false;
    private GameObject _fireVisuals;

    private void Start()
    {
        _fireVisuals = (GameObject)Resources.Load("Prefabs/TorchFire", typeof(GameObject));
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fire-Stone"))
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

            SoundManager.PlaySound("Fire", firePosition);

            openEvent.Invoke();
        }
        _onFire = true;
    }
}
