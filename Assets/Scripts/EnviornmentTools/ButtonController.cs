using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Animator _animator;

    private bool _isDown = true;

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
        _isDown = !_isDown;
        _animator.SetBool("isDown", _isDown);
        _lastTriggerTime = Time.time;
    }
}
