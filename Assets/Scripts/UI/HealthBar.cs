using UnityEngine;

namespace Assets.Scripts.UI
{
    using Actors;

    [RequireComponent(typeof(ProgressBar))]
    public class HealthBar : MonoBehaviour
    {
        public ActorHealthState HealthState;

        private ProgressBar _progressBar;

        public void Start()
        {
            _progressBar = GetComponent<ProgressBar>();
        }

        public void Update()
        {
            _progressBar.SetProgress(HealthState.HealthPercentage);
        }
    }
}
