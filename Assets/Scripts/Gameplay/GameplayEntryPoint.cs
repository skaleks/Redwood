using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace Gameplay
{
    public class GameplayEntryPoint : IStartable
    {
        [Inject] private CharacterSpawner _characterSpawner;
        
        public void Start()
        {
            _characterSpawner.Initialize();
            _characterSpawner.SpawnPlayer();
            _characterSpawner.SpawnEnemies().Forget();
        }
    }
}