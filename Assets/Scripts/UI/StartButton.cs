using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class StartButton : MonoBehaviour
    {
        public void OnClicked()
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
