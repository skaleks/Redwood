using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private List<Transform> _enemySpawnPoints;

        public Transform PlayerSpawnPoint => _playerSpawnPoint;
        
        public List<Transform> EnemySpawnPoints => _enemySpawnPoints;
    }
}