using Unity.VisualScripting;
using UnityEngine;

public class PlayerTakeHit : IPlayerStatePattern
{
    private PlayerController _playerController;
    private Animator _animator;
    
    //constructor
    public PlayerTakeHit(PlayerController _playerController)
    {
        this._playerController = _playerController;
        _animator = _playerController._animator;
    }
    public void Enter()
    {
        _animator.SetInteger("Status", 7);
    }

    public void Update()
    {
        
    }


    public void Exit()
    {
        
    }
}