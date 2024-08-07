using Data;
using Gameplay.Player;

namespace Gameplay.Interfaces
{
    public interface ICharacterFactory
    {
        public PlayerModel CreatePlayer(PlayerData data);
        public ICharacterModel CreateEnemy(IEnemyData data);
    }
}