using Assets.Scripts.Actors.Weapons;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class ActorHealthState : MonoBehaviour, IDamageable
    {
        public uint MaxHealth;

        public uint Health { get; private set; }
        public float HealthPercentage
        {
            get
            {
                return (float) Health / (float) MaxHealth;
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
            Debug.Log("Taking damage!");

            if (damager.Damage >= Health)
                Health = 0;
            else
                Health -= damager.Damage;
        }
    }
}
