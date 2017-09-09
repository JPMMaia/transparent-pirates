using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Actors.Weapons.Pistols
{
    public class Bullet : MonoBehaviour, IDamager
    {
        public uint Damage
        {
            get
            {
                return _damage;
            }
        }
        public List<String> IgnoreTags
        {
            get
            {
                return _ignoreTags;
            }
        }

        private List<String> _ignoreTags;
        private uint _damage;

        public void OnCollisionEnter(Collision other)
        {
            if (_ignoreTags.Exists(e => e == other.gameObject.tag))
                return;

            var damageables = other.gameObject.GetComponents<IDamageable>();

            foreach(var damageable in damageables)
            {
                damageable.TakeDamageFrom(this);
            }

            Destroy(this.gameObject);
        }
    }
}
