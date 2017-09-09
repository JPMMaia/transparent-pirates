using System;
using Assets.Scripts.Actors.Weapons;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class ActorHealthState : MonoBehaviour, IDamageable
    {
        public event EventHandler OnDie;

        public uint MaxHealth;

        public uint Health { get; private set; }
        public float HealthPercentage
        {
            get
            {
                return (float)Health / (float)MaxHealth;
            }
        }
        public bool IsDeath
        {
            get
            {
                return Health == 0;
            }
        }

        public void Start()
        {
            Health = MaxHealth;
        }

        public void TakeDamageFrom(IDamager damager)
        {
            if (IsDeath)
                return;

            if (damager.Damage >= Health)
            {
                Health = 0;

                if (OnDie != null)
                    OnDie(this, EventArgs.Empty);

                return;
            }

            Health -= damager.Damage;
        }
    }
}
