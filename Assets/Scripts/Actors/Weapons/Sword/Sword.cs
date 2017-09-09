using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Actors.Weapons.Sword
{
    public class Sword : IWeapon
    {
        private GameObject _holder;

        public Sword(GameObject holder)
        {
            _holder = holder;
        }

        public void Attack()
        {
            var position = _holder.transform.position;

            var objects = Object.FindObjectsOfType<GameObject>();

            var swordAttack = new SwordAttack(2);

            foreach(var obj in objects)
            {
                var otherPosition = obj.transform.position;
                var deltaPosition = otherPosition - position;
                if(deltaPosition.magnitude < 1.8f)
                {
                    var damageables = obj.GetInterfaces<IDamageable>();
                    foreach(var damageable in damageables)
                    {
                        damageable.TakeDamageFrom(swordAttack);
                    }
                }
            }
        }
    }
}
