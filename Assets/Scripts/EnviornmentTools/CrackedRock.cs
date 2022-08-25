using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackedRock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Explosion-Stone"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Explosion-Stone"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
