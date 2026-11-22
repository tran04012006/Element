using UnityEngine;

public class PlayerJump : IPlayerStatePattern
{
    private PlayerController _playerController;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private float duration;
    
    //constructor
    public PlayerJump(PlayerController _playerController)
    {
        this._playerController = _playerController;
        
        _animator = _playerController._animator;
        _rigidbody2D = _playerController.GetComponent<Rigidbody2D>();
    }

    public void Enter()
    {
        _animator.SetInteger("Status", 2);
    }

    public void Update()
    {

        if (_playerController.isJumping == false)
        {
            _playerController.ChangeState(_playerController.playerIdle);
        }

    }

    public void Exit()
    {
        
    }
}