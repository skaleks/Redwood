using Data;
using Input;
using UnityEngine;
using VContainer;

namespace Gameplay.Player
{
    public class PlayerModel
    {
        [Inject] private InputHandler _input;
        private Player _player;
        private PlayerData _playerData;
        private Animator _animator;
        
        public Transform Transform { get; }

        public PlayerModel(Player player, PlayerData playerData)
        {
            _player = player;
            _playerData = playerData;
            _animator = player.Animator;
            Transform = player.transform;
        }

        public void Move(Vector2 moveDelta)
        {
            SetAnimation("Run");
            // Здесь двигаемся
        }

        private void Fire()
        {
            SetAnimation("Fire");
        }

        private void Turn()
        {
            // поворачиваем тело
        }

        private void SetAnimation(string animationName)
        {
            _animator.SetTrigger(animationName);
        }
    }
}