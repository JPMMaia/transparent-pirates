using UnityEngine;

namespace Assets.Scripts.Actors.Weapons.Pistols
{
    public class Pistol : MonoBehaviour, IWeapon
    {
        public float MaxCooldown = 0.3f;
        public float CurrentCooldown = 0.0f;

        public Bullet BulletPrefab;
        public float BulletInitialVelocity = 1.0f;
        public string[] IgnoreTags;

        public void Attack()
        {
            if (CurrentCooldown < MaxCooldown)
                return;
            CurrentCooldown = 0.0f;

            var origin = transform.position;
            var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var direction = (target - origin).normalized;

            var bullet = Instantiate(BulletPrefab, origin, new Quaternion(0.0f, 0.0f, 0.0f, 1.0f));
            bullet.Damage = 2;
            foreach(var tag in IgnoreTags)
                bullet.IgnoreTags.Add(tag);

            var bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidBody.velocity = new Vector2(direction.x, direction.y) * BulletInitialVelocity;
        }

        public void FixedUpdate()
        {
            CurrentCooldown += Time.fixedDeltaTime;
        }
    }
}
