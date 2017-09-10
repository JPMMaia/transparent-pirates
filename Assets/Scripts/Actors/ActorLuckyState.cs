using UnityEngine;

namespace Assets.Scripts.Actors
{
    public class ActorLuckyState : MonoBehaviour
    {
        public float MaxLuck = 100.0f;
        public float CurrentLuck;
        public float DecreaseBySecond = 10.0f;

        public bool IsActive { get; private set; }
        public float Percentage
        {
            get
            {
                return (float) CurrentLuck / (float) MaxLuck;
            }
        }
        public float DamageMultiplier
        {
            get
            {
                if (!IsActive)
                    return 1.0f;

                var damage = Random.Range(.8f, 1.2f);
                if (Random.Range(0f, 1f) < .7f)
                {
                    damage *= 3.0f;
                    Debug.Log("Crit");
                }

                return damage;
            }
        }
        private bool _done = false;

        public void Awake()
        {
            IsActive = false;
        }

        public void Start()
        {
            CurrentLuck = MaxLuck;
        }

        public void Activate()
        {
            if (_done)
                return;

            if (IsActive)
                return;

            IsActive = true;
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                Activate();
            }
        }

        public void FixedUpdate()
        {
            if (!IsActive)
                return;

            CurrentLuck -= DecreaseBySecond * Time.fixedDeltaTime;
            
            if(CurrentLuck < 0.0f)
            {
                CurrentLuck = 0.0f;
                IsActive = false;
                _done = true;
            }
        }
    }
}
