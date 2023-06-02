using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _playerRig;

        public void SetPlayerDeadAnimation()
        {
            _animator.enabled = false;
            _playerRig.SetActive(true);
        }
    }
}