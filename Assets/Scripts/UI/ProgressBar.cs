using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ProgressBar : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private float _initialWidth;

        public void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _initialWidth = _rectTransform.rect.width;
        }

        public void SetProgress(float percentage)
        {
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _initialWidth * percentage);
        }
    }
}
