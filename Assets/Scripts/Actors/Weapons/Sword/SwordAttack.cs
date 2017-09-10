namespace Assets.Scripts.Actors.Weapons.Sword
{
    public class SwordAttack : IDamager
    {
        public float Damage
        {
            get
            {
                return _damage;
            }
        }

        private float _damage;

        public SwordAttack(float damage)
        {
            _damage = damage;
        }
    }
}
