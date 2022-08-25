using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour
{
    // Should the doors that are listening open or close?
    public UnityEvent openEvent;
    public UnityEvent closeEvent;

    private Animator _animator;
    private bool _buttonOff = true;

    // Slows how fast you can trigger the same button.
    //(Mainly for Explosion and Fire stone having more than one collision.)
    private float _triggerDelay = 0.5f;
    private float _lastTriggerTime;

    private string[] _allowedTags = { "Player", "Stone", "Explosion-Stone", "Fire-Stone",
                                      "Mind-Control-Stone", "Joker-Stone", "Bounce-Stone" };

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _lastTriggerTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (string tag in _allowedTags)
        {
            if (other.CompareTag(tag))
            {
                if (Time.time - _lastTriggerTime > _triggerDelay)
                {
                    ToggleButton();
                }
                break;
            }
        }
    }

    private void ToggleButton()
    {
        _buttonOff = !_buttonOff;
        _animator.SetBool("isOff", _buttonOff);
        _lastTriggerTime = Time.time;
        if (!_buttonOff)
        {
            openEvent.Invoke();
        }
        else
        {
            closeEvent.Invoke();
        }
    }
}
