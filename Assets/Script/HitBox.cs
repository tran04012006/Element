using System;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
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
        throw new NotImplementedException();
    }
}
