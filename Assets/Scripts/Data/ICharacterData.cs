using UnityEditor.Animations;

namespace Data
{
    public interface ICharacterData
    {
        public AnimatorController Animator { get; }
        public float Speed { get; }
    }
}