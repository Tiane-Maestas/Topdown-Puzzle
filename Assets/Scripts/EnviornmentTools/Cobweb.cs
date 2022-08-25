using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cobweb : MonoBehaviour
{
    [SerializeField] private float _cobwebDestructionDelay = 1f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fire-Stone"))
        {
            GameObject.Destroy(this.gameObject, _cobwebDestructionDelay);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Fire-Stone"))
        {
            GameObject.Destroy(this.gameObject, _cobwebDestructionDelay);
        }
    }
}
