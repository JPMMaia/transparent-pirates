using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionFun : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject InstructionPanel;

    // Use this for initialization
    public void onclicked()
    {
        MainPanel.SetActive(false);
        InstructionPanel.SetActive(true);
    }
}
