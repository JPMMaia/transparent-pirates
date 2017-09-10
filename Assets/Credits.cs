using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject CreditsPanel;

    // Use this for initialization
    public void onclicked()
    {
        MainPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }
}
