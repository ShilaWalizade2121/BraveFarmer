using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{

    public GameObject panel;

    public void ActivePanel()
    {
        panel.SetActive(true);
    }

    public void InActivePanel()
    {
        panel.SetActive(false);
    }





}
