using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackInst : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject InstructionPanel;

    // Use this for initialization
    public void onclicked()
    {
        MainPanel.SetActive(true);
        InstructionPanel.SetActive(false);
    }
}
