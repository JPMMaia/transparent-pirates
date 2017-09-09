using Assets.Scripts.Actors.Weapons;

namespace Assets.Scripts.Actors
{
    public class ActorHealthState : IDamageable
    {
        public uint Health { get; private set; }
        public float HealthPercentage
        {
            get
            {
                return (float) Health / (float) _maxHealth;
            }
        }
        public bool IsDeath
        {
            get
            {
                return Health == 0;
            }
        }

        private uint _maxHealth;

        public ActorHealthState(uint maxHealth)
        {
            _maxHealth = maxHealth;
            Health = maxHealth;
        }

        public void TakeDamageFrom(IDamager damager)
        {
            if (damager.Damage >= Health)
                Health = 0;
            else
                Health -= damager.Damage;
        }
    }
}
