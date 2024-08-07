using Data;
using Gameplay.Enemy;
using Gameplay.Interfaces;
using Gameplay.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gameplay
{
    public class CharacterFactory : ICharacterFactory
    {
        [Inject] private PrefabDatabase _prefabDatabase;

        private IObjectResolver _container;
        
        public CharacterFactory(IObjectResolver container)
        {
            _container = container;
        }

        public PlayerModel CreatePlayer(PlayerData data)
        {
            var player = _container.Instantiate(_prefabDatabase.Player);
            return new PlayerModel(player, data);
        }

        public ICharacterModel CreateEnemy(IEnemyData data)
        {
            var enemy = _container.Instantiate(_prefabDatabase.Zombie);
            return new ZombieModel(enemy, data);
        }
    }
}