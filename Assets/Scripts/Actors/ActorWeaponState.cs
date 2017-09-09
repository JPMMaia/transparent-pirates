using Assets.Scripts.Actors.Weapons;

namespace Assets.Scripts.Actors
{
    public class ActorWeaponState
    {
        private IWeapon _weapon;

        public ActorWeaponState(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public void Attack()
        {
            _weapon.Attack();
        }
    }
}
