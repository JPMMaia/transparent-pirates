using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ExitButton : MonoBehaviour
    {
        public void OnClicked()
        {
            Application.Quit();
        }
    }
}
