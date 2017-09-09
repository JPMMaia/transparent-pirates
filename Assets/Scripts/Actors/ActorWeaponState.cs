using Assets.Scripts.Actors.Weapons;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class ActorWeaponState : MonoBehaviour
    {
        public GameObject Weapon;
        private IWeapon _weapon;

        public void Awake()
        {
            _weapon = Weapon.GetComponent<IWeapon>();
        }

        public void Attack()
        {
            _weapon.Attack();
        }
    }
}
