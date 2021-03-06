﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Actors.Weapons.Pistols
{
    public class Bullet : MonoBehaviour, IDamager
    {
        public float Damage
        {
            get
            {
                return _damage * DamageMultiplier;
            }
            set
            {
                _damage = value;
            }
        }
        public List<String> IgnoreTags
        {
            get
            {
                return _ignoreTags;
            }
        }
        

        public float DamageMultiplier = 1.0f;

        private List<String> _ignoreTags = new List<string>();
        private float _damage;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (_ignoreTags.Exists(e => e == other.gameObject.tag))
                return;

            var damageables = other.gameObject.GetComponents<IDamageable>();
            var damageablesP = other.gameObject.GetComponentsInParent<IDamageable>();

            List<IDamageable> list = new List<IDamageable>();

            foreach (var d in damageablesP)
                list.Add(d);
            foreach (var d in damageables)
                list.Add(d);

            foreach (var damageable in list)
            {
                damageable.TakeDamageFrom(this);
            }

            SoundPrefabs.Instance.BulletsAudioSource.Play();
            Destroy(this.gameObject);
        }
    }
}
