using UnityEngine;

public class PlayerIdle : IPlayerStatePattern
{
    private PlayerController _playerController;
    private Animator _animator;
    
    //constructor
    public PlayerIdle(PlayerController _playerController)
    {
        this._playerController = _playerController;
        _animator = _playerController._animator;
    }
    public void Enter()
    {
        _animator.SetInteger("Status", 0);
    }

    public void Update()
    {
        if (_playerController.moveX != 0)
        {
            _playerController.ChangeState(_playerController.playerRun);
        }

        if (_playerController.isJumping == true && _playerController.isGround == true)
        {
            _playerController.ChangeState(_playerController.playerJump);
        }
    }


    public void Exit()
    {
        
    }
}