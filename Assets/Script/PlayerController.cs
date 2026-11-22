using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public bool isRight;
    public float moveX;
    public float moveY;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isMoving;
    private Vector2 direction;
    
    [Header("PlayerState")]
    private IPlayerStatePattern currentState;
    public PlayerIdle playerIdle;
    public PlayerRun playerRun;
    public PlayerJump playerJump;
    public PlayerAttack playerAttack;
    
    [Header("Control")]
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode atk1Key = KeyCode.J;
    
    [Header("Component")]
    public Animator _animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;
    
    //attack
    public enum AttackType
    {
        PlayerLightAttack,
        NoAttack,
    }
    public AttackType currentAttackType;
    
    [Header("Boolean")]
    public bool isGround = true;
    public bool isJumping = false;
    public bool recover = false;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerIdle = new PlayerIdle(this);
        playerRun = new PlayerRun(this);
        playerJump = new PlayerJump(this);
        playerAttack = new PlayerAttack(this);
        ChangeState(playerIdle);
        currentAttackType = AttackType.NoAttack;
    }
    public void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(moveX * moveSpeed, rigidbody2D.linearVelocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        Direction();
        Movement();
        Attack();
        if (moveX == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        currentState.Update();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("isGround"))
        {
            //dang cham dat
            isGround = true;
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("isGround"))
        {
            //dang roi khoi dat
            isGround = false;
        }
        
    }

    public void Movement()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    private void Direction()
    {
        if (moveX == -1)
        {
            //di sang trai
            isRight = false;
            spriteRenderer.flipX = true;
        }
        
        if (moveX == 1)
        {
            //di sang phai
            isRight = true;
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(upKey))
        {
            //neu nguoi choi muon player nhay len khi player dang cham dat
            if (isGround == true)
            {
                isJumping = true;
                rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpForce);
            }
        }
    }
    
    public void ChangeState(IPlayerStatePattern newState)
    {
        if (currentState == newState)
            return;

        currentState?.Exit();

        currentState = newState;
        currentState.Enter();
    }
    

    void Attack()
    {
        if (Input.GetKeyDown(atk1Key))
        {
            recover = false;
            Debug.Log("di vao attack");
            Debug.Log("currentAttackType: " + currentAttackType);
            currentAttackType = AttackType.PlayerLightAttack;
        }
    }

    public void Recover()
    {
        Debug.Log("chay recover");
        Debug.Log("currentAttackType: " + currentAttackType);
        currentAttackType = AttackType.NoAttack;
        recover = true;
        //ChangeState(playerIdle);
    }
}
