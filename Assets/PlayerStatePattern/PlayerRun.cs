using UnityEngine;

public class PlayerRun : IPlayerStatePattern
{
    private PlayerController _playerController;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private float duration;
    
    //constructor
    public PlayerRun(PlayerController _playerController)
    {
        this._playerController = _playerController;
        
        _animator = _playerController._animator;
        _rigidbody2D = _playerController.GetComponent<Rigidbody2D>();
    }

    public void Enter()
    {
        _animator.SetInteger("Status", 1);
    }

    public void Update()
    {
        if (_playerController.moveX == 0)
        {
            _playerController.ChangeState(_playerController.playerIdle);
        }
        if (_playerController.isJumping == true && _playerController.isGround == true)
        {
            _playerController.ChangeState(_playerController.playerJump);
        }
        if (_playerController.currentAttackType != PlayerController.AttackType.NoAttack)
        { 
            _playerController.ChangeState(_playerController.playerAttack);
        }
    }

    public void Exit()
    {
        
    }
}