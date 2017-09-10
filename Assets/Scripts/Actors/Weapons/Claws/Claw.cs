using System;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Actors.Weapons.Claws
{
    class Claw : MonoBehaviour, IWeapon
    {

        public void Attack()
        {
            var range = 2f;
            var collisionCenter = transform.parent.position + transform.parent.right * range;
            var swordAttack = new ClawAttack(20);

            var allObjects = GameObject.FindGameObjectsWithTag("Player");

            foreach (var obj in allObjects)
            {
                if (obj == transform.parent.gameObject)
                    continue;

                var direction = obj.transform.position - transform.parent.position;
                var dotProduct = Vector3.Dot(direction, -transform.right);
                if (dotProduct < 0.0f)
                    continue;

                var deltaPosition = obj.transform.position - collisionCenter;
                if (deltaPosition.magnitude > 1.0f)
                    continue;

                var damageables = obj.GetInterfaces<IDamageable>();
                foreach (var damageable in damageables)
                {
                    damageable.TakeDamageFrom(swordAttack);
                }
            }
        }
    }
}
