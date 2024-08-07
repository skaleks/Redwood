using System;

namespace Gameplay.Interfaces
{
    public interface IDamageable
    {
        public Action<float> OnDamage { get; set; }
        public void Damage(float value);
    }
}