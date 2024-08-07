using System;
using UnityEngine;

namespace Gameplay.Interfaces
{
    public interface ICharacterModel
    {
        public Transform Transform { get; }
        public Action<ICharacterModel> OnDestroy { set; }
        public void Initialize(Transform target);
        public void Run();
    }
}