using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D _playerBody;
    Vector2 movement;
    private Animator _animator;

    private void Awake()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        _playerBody.MovePosition(_playerBody.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        _animator.SetFloat("playerSpeed", movement.magnitude);
        if (movement != Vector2.zero)
        {
            // Lerp Here
            _playerBody.rotation = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;
        }
    }
}
