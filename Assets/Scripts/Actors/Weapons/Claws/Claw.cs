using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Actors.Weapons.Claws
{
    class Claw : MonoBehaviour, IWeapon
    {
        public float MaxCooldown = 1.0f;
        public float CurrentCooldown = 0.0f;

        public float DamageMultiplier = 20.0f;

        public void Attack()
        {
            if (CurrentCooldown < MaxCooldown)
                return;
            CurrentCooldown = 0.0f;

            var range = 3f;
            var collisionCenter = transform.parent.position + transform.parent.up * range;
            
            var swordAttack = new ClawAttack((uint)DamageMultiplier);

            var allObjects = GameObject.FindGameObjectsWithTag("Player");

            foreach (var obj in allObjects)
            {
                if (obj == transform.parent.gameObject)
                    continue;

                var direction = obj.transform.position - transform.parent.position;
                var dotProduct = Vector3.Dot(direction, transform.up);
                if (dotProduct < 0.0f)
                    continue;

                var deltaPosition = obj.transform.position - collisionCenter;
                if (deltaPosition.magnitude > 2.0f)
                    continue;

                var damageables = obj.GetInterfaces<IDamageable>();
                foreach (var damageable in damageables)
                {
                    damageable.TakeDamageFrom(swordAttack);
                }
            }
        }

        public void FixedUpdate()
        {
            CurrentCooldown += Time.fixedDeltaTime;
        }
    }
}
