using System;
using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class SoundPrefabs : MonoBehaviour
    {
        private static SoundPrefabs _instance;
        public static SoundPrefabs Instance
        {
            get
            {
                if (!_instance)
                    _instance = FindObjectOfType<SoundPrefabs>();

                return _instance;
            }
        }

        public AudioSource BulletsAudioSource;
    }
}
