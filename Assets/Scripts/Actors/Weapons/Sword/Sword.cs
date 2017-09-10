using System;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Actors.Weapons.Sword
{
    public class Sword : MonoBehaviour, IWeapon
    {
        public float MaxCooldown = 1.0f;
        public float CurrentCooldown = 0.0f;
        public float DamageMultiplier = 5.0f;

        public void Attack()
        {
            if (CurrentCooldown < MaxCooldown)
                return;
            CurrentCooldown = 0.0f;

            GetComponent<AudioSource>().Play();

            var range = 0.6f;
            var collisionCenter = transform.parent.position + transform.parent.right * range;
            var swordAttack = new SwordAttack((uint) DamageMultiplier);

            var allObjects = GameObject.FindObjectsOfType<GameObject>();
            foreach (var obj in allObjects)
            {
                if (obj == transform.parent.gameObject)
                    continue;

                var direction = obj.transform.position - transform.parent.position;
                var dotProduct = Vector3.Dot(direction, transform.right);
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

        public void FixedUpdate()
        {
            CurrentCooldown += Time.fixedDeltaTime;
        }
    }
}
