using Gameplay.Enemy;
using Gameplay.Player;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PrefabDatabase", menuName = "Data/DB/PrefabDatabase", order = 0)]
    public class PrefabDatabase : ScriptableObject
    {
        [SerializeField] private Player _player;
        [SerializeField] private Zombie _zombie;

        public Player Player => _player;
        public Zombie Zombie => _zombie;
    }
}