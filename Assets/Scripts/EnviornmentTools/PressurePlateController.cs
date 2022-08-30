using UnityEngine;
using UnityEngine.Events;
using Nebula;

public class PressurePlateController : MonoBehaviour
{
    // Should the doors that are listening open or close?
    public UnityEvent openEvent;
    public UnityEvent closeEvent;

    private Animator _animator;
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("isDown", true);
            openEvent.Invoke();
            SoundManager.PlaySound("Button", this.transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("isDown", false);
            closeEvent.Invoke();
            SoundManager.PlaySound("Button", this.transform.position);
        }
    }
}
