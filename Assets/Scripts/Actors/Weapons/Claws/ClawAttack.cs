using System;

namespace Assets.Scripts.Actors.Weapons.Claws
{
    class ClawAttack : IDamager
    {
        public float Damage
        {
            get
            {
                return _damage;
            }
        }

        private float _damage;

        public ClawAttack(float damage)
        {
            _damage = damage;
        }
    }
}
