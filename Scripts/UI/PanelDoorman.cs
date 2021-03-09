using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelDoorman : MonoBehaviour
{
    [SerializeField] private DialogStartButton _dialogStartButton;

    public void OnClickExitButton( GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OnClickOpenButton(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void OnOpenStartDialogButton(NPC npc)
    {
        _dialogStartButton.gameObject.SetActive(true);
        _dialogStartButton.SetNPC(npc);
    }

    public void OnCloseStartDialogButton()
    {
        _dialogStartButton.gameObject.SetActive(false);
    }
}