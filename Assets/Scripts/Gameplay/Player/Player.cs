using System;
using Gameplay.Interfaces;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player : MonoBehaviour, ICharacter, IDamageable
    {
        [SerializeField] private Animator _animator;
        public Animator Animator => _animator;
        public Action<float> OnDamage { get; set; }

        public void Damage(float value) => OnDamage?.Invoke(value);
    }
}