using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameplayDataBase", menuName = "Data/DB/GameplayDataBase", order = 1)]
    public class GameplayDataBase : ScriptableObject
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private List<ZombieData> _zombieData;
        [SerializeField] private float _enemySpawnDelay;


        public PlayerData PlayerData => _playerData;
        public List<ZombieData> ZombieData => _zombieData;
        public float EnemySpawnDelay => _enemySpawnDelay;
    }
}