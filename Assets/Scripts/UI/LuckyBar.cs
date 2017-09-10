using UnityEngine;

namespace Assets.Scripts.UI
{
    using Actors;

    public class LuckyBar : MonoBehaviour
    {
        public GameObject Bar;
        public ActorLuckyState LuckyState;
        public ProgressBar ProgressBar;

        public void Start()
        {
            Bar.SetActive(LuckyState.IsActive);
        }

        public void Update()
        {
            Bar.SetActive(LuckyState.IsActive);
            ProgressBar.SetProgress(LuckyState.Percentage);
        }
    }
}
