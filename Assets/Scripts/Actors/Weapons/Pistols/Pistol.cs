using UnityEngine;

namespace Assets.Scripts.Actors.Weapons.Pistols
{
    public class Pistol : MonoBehaviour, IWeapon
    {
        public Bullet BulletPrefab;
        public float BulletInitialVelocity = 1.0f;
        public string[] IgnoreTags;

        public void Attack()
        {
            var origin = transform.position;
            var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var direction = (target - origin).normalized;

            var bullet = Instantiate(BulletPrefab, origin, new Quaternion(0.0f, 0.0f, 0.0f, 1.0f));
            foreach(var tag in IgnoreTags)
                bullet.IgnoreTags.Add(tag);

            var bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidBody.velocity = new Vector2(direction.x, direction.y) * BulletInitialVelocity;
        }
    }
}
