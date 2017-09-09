using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Actors.Weapons.Sword
{
    public class Sword : MonoBehaviour, IWeapon
    {
        public void Attack()
        {
            var range = 0.6f;
            var collisionCenter = transform.parent.position + transform.parent.right * range;
            var swordAttack = new SwordAttack(2);

            var allObjects = Object.FindObjectsOfType<GameObject>();
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
    }
}
