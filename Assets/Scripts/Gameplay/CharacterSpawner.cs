using Cysharp.Threading.Tasks;
using Data;
using Gameplay.Interfaces;
using Gameplay.Player;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;

namespace Gameplay
{
    public class CharacterSpawner
    {
        [Inject] private ICharacterFactory _factory;
        [Inject] private GameplayDataBase _gameplayData;
        [Inject] private SceneData _sceneData;

        private ObjectPool<ICharacterModel> _zombiePool;
        private PlayerModel _player;
        
        public void Initialize()
        {
            _zombiePool = new ObjectPool<ICharacterModel>(Create, Get, Release);
        }
        
        public void SpawnPlayer()
        {
            _player = _factory.CreatePlayer(_gameplayData.PlayerData);
            _player.Transform.position = _sceneData.PlayerSpawnPoint.position;
        }

        public async UniTask SpawnEnemies()
        {
            await UniTask.WaitForSeconds(_gameplayData.EnemySpawnDelay);
            var enemy = _zombiePool.Get();
            enemy.OnDestroy = OnEnemyDestroy;
        }

        private void OnEnemyDestroy(ICharacterModel enemy)
        {
            _zombiePool.Release(enemy);
        }

        private void Release(ICharacterModel enemy)
        {
            enemy.Transform.gameObject.SetActive(false);
        }

        private void Get(ICharacterModel enemy)
        {
            enemy.Transform.position = _sceneData.EnemySpawnPoints[Random.Range(0, _sceneData.EnemySpawnPoints.Count)].position;
            enemy.Initialize(_player.Transform);
            enemy.Run();
        }

        private ICharacterModel Create()
        {
            return _factory.CreateEnemy(_gameplayData.ZombieData[Random.Range(0, _gameplayData.ZombieData.Count)]);
        }
    }
}