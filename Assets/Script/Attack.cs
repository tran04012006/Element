using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;

    private EnemyController owner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        owner = GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            owner.attackPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            owner.attackPlayer = false;
        }    
    }
}
