using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BackFun : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject CreditsPanel;

    // Use this for initialization
    public void onclicked()
    {
        MainPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }
}

