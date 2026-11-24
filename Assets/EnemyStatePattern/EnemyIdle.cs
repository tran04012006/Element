using UnityEngine;

public class EnemyIdle : IEnemyStatePattern
{
    private EnemyController _enemyController;
    private Animator _animator;
    
    //constructor
    public EnemyIdle(EnemyController _enemyController)
    {
        this._enemyController = _enemyController;
        _animator = _enemyController._animator;
    }
    public void Enter()
    {
        Debug.Log("chay EnemyIdle");
        _animator.SetInteger("Status", 0);
    }

    public void Update()
    {
        if (_enemyController.attackPlayer == true)
        { 
            Debug.Log("chuyen sang attack");
            _enemyController.ChangeState(_enemyController.enemyAttack);
        }
    }


    public void Exit()
    {
        
    }
}