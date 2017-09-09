namespace Assets.Scripts.Actors.Weapons.Sword
{
    public class SwordAttack : IDamager
    {
        public uint Damage
        {
            get
            {
                return _damage;
            }
        }

        private uint _damage;

        public SwordAttack(uint damage)
        {
            _damage = damage;
        }
    }
}
