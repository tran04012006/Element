using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Component")]
    public Animator _animator;
    private Attack attack;
    
    [Header("Boolean")]
    public bool attackPlayer = false;
    
    [Header("PlayerState")]
    private IEnemyStatePattern currentState;
    public EnemyIdle enemyIdle;
    public EnemyAttack enemyAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        attack = GetComponent<Attack>();

        enemyIdle = new EnemyIdle(this);
        enemyAttack = new EnemyAttack(this);
        
        ChangeState(enemyIdle);
    }

    // Update is called once per frame
    void Update()
    {

        currentState?.Update();
    }
    
    public void ChangeState(IEnemyStatePattern newState)
    {
        Debug.Log("doi sang trang thai " + newState);
        if (currentState == newState)
            return;

        currentState?.Exit();

        currentState = newState;
        currentState.Enter();
    }


}
