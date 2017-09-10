using System;

namespace Assets.Scripts.Actors.Weapons.Claws
{
    class ClawAttack : IDamager
    {
        public uint Damage
        {
            get
            {
                return _damage;
            }
        }

        private uint _damage;

        public ClawAttack(uint damage)
        {
            _damage = damage;
        }
    }
}
