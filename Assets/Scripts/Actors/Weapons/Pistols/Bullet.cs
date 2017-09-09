using System;
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

        private uint _damage;
    }
}
