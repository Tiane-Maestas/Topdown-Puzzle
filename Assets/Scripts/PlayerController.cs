using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;

    public bool playerControllerSystem = true; // true for follow mouse

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        if (playerControllerSystem)
        {
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
        else
        {
            if (movement != Vector2.zero)
            {
                rb.rotation = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg - 90f;
            }
        }
    }

    public void SwitchPlayerControllerSystem()
    {
        playerControllerSystem = !playerControllerSystem;
    }
}
