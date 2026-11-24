using System;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public BoxCollider2D _boxCollider2D;

    private PlayerController owner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        owner = GetComponentInParent<PlayerController>();
        _boxCollider2D.enabled = false; //mac dinh la collider tat 
    }

    public void EnableHitBox()
    {
        _boxCollider2D.enabled = true;
    }

    public void DisableHitBox()
    {
        _boxCollider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.ChangeState(playerController.playerTakeHit);
        }
    }
}
