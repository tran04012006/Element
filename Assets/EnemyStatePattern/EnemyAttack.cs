using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : IEnemyStatePattern
{
    private EnemyController _enemyController;
    private Animator _animator;
    
    //constructor
    public EnemyAttack(EnemyController _enemyController)
    {
        this._enemyController = _enemyController;
        _animator = _enemyController._animator;
    }
    public void Enter()
    {
        _animator.SetInteger("Status", 1);
    }

    public void Update()
    {
        if (_enemyController.attackPlayer == false)
        { 
            _enemyController.ChangeState(_enemyController.enemyIdle);
        }
    }


    public void Exit()
    {
        
    }
}