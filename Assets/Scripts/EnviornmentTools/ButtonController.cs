using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Animator _animator;

    private bool _isDown = true;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Stone"))
        {
            _isDown = !_isDown;
            _animator.SetBool("isDown", _isDown);
        }
    }

}
