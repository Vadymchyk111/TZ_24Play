using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private PlayerCubeHolder _playerCubeHolder;
        [SerializeField] private PlayerAnimationController _animationController;
        [SerializeField] private PlayerMoveByTouch _playerMove;

        private void OnEnable()
        {
            _playerCubeHolder.OnLastCubeDetached += _gameManager.SetGameOver;
            _playerCubeHolder.OnLastCubeDetached += _animationController.SetPlayerDeadAnimation;
            _playerCubeHolder.OnLastCubeDetached += () => _playerMove.enabled = false;
        }

        private void OnDisable()
        {
            _playerCubeHolder.OnLastCubeDetached -= _gameManager.SetGameOver;
            _playerCubeHolder.OnLastCubeDetached -= _animationController.SetPlayerDeadAnimation;
        }
    }
}
