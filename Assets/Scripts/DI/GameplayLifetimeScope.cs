using Data;
using Gameplay;
using Gameplay.Interfaces;
using Input;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        [SerializeField] private PrefabDatabase _prefabDatabase;
        [SerializeField] private GameplayDataBase _gameplayDataBase;
        [SerializeField] private SceneData _sceneData;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayEntryPoint>();
            builder.Register<InputHandler>(Lifetime.Singleton);
            builder.Register<CharacterSpawner>(Lifetime.Scoped);
            builder.Register<CharacterFactory>(Lifetime.Scoped).As<ICharacterFactory>();
            builder.RegisterInstance(_prefabDatabase);
            builder.RegisterInstance(_gameplayDataBase);
            builder.RegisterInstance(_sceneData);
        }
    }
}