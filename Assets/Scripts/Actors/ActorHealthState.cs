using System;
using Assets.Scripts.Actors.Weapons;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class ActorHealthState : MonoBehaviour, IDamageable
    {
        public event EventHandler OnDie;

        public float MaxHealth;
        public float Health;

        public float HealthPercentage
        {
            get
            {
                return Health / MaxHealth;
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

          

            Health -= Mathf.FloorToInt(damager.Damage);
            
            if (Health <= 0)
            {
                Health = 0;

                if (OnDie != null)
                    OnDie(this, EventArgs.Empty);

                return;
            }

        }
    }
}
