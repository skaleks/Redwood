using System;
using Data;
using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Enemy
{
    public class ZombieModel : ICharacterModel
    {
        private Zombie _zombie;
        private float _speed;
        private float _health;
        private Transform _playerTarget;
        
        public Transform Transform { get; }
        public Action<ICharacterModel> OnDestroy { get; set; }
       
        public ZombieModel(Zombie zombie, IEnemyData data)
        {
            _zombie = zombie;
            _zombie.Animator.runtimeAnimatorController = data.Animator;
            _speed = data.Speed;
            _health = data.Health;
            Transform = zombie.transform;
        }

        public void Initialize(Transform target)
        {
            _playerTarget = target;
            _zombie.OnDamage = Damage;
            _zombie.gameObject.SetActive(true);
        }

        public void Run()
        {
            Turn();
            Vector3.MoveTowards(Transform.position, _playerTarget.position, _speed * Time.deltaTime);
        }

        private void Turn()
        {
            var direction = _playerTarget.position.x - Transform.position.x > 0 ? 1 : -1; // Находим игрока
            Transform.localScale = new Vector3(direction, 1, 1);
        }

        private void Damage(float value)
        {
            // Отсечь здоровье и чекнуть смерть
            OnDestroy?.Invoke(this);
        }
    }
}