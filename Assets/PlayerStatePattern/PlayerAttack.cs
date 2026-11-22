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
        
        if (_playerController.currentAttackType == PlayerController.AttackType.PlayerLightAttack)
        {
            _animator.SetInteger("Status", 3);
        }
        
    }

    public void Update()
    {
        
        if (_playerController.recover == true)
        {
            _playerController.ChangeState(_playerController.playerIdle);
        }
        
    }


    public void Exit()
    {
        
    }
}