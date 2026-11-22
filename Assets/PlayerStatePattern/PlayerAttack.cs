using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : IPlayerStatePattern
{
    private PlayerController _playerController;
    private Animator _animator;
    
    //constructor
    public PlayerAttack(PlayerController _playerController)
    {
        this._playerController = _playerController;
        _animator = _playerController._animator;
    }
    public void Enter()
    {
        if (_playerController.currentAttackType == PlayerController.AttackType.Attack1)
        {
            _animator.SetInteger("Status", 3);
        }
        if (_playerController.currentAttackType == PlayerController.AttackType.Attack2)
        {
            _animator.SetInteger("Status", 4);
        }
        if (_playerController.currentAttackType == PlayerController.AttackType.Attack3)
        {
            _animator.SetInteger("Status", 5);
        }

        if (_playerController.currentAttackType == PlayerController.AttackType.AirAttack)
        {
            _animator.SetInteger("Status", 6);
        }
    }

    public void Update()
    {
        
    }


    public void Exit()
    {
        
    }
}