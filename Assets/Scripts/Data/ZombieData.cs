using UnityEditor.Animations;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ZombieData", menuName = "Data/ZombieData", order = 1)]
    public class ZombieData : ScriptableObject, IEnemyData
    {
        [SerializeField] private AnimatorController _animator;
        [SerializeField] private float _speed;
        [SerializeField] private float _health;

        public AnimatorController Animator => _animator;

        public float Speed => _speed;

        public float Health => _health;
    }
}