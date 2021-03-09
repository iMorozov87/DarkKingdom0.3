using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DialogStartButton : MonoBehaviour
{
    [SerializeField] private PanelDoorman _menu;
    [SerializeField] private GameObject _panel;
    [SerializeField] private DialogDisplay _dialogDisplay;

    private Button _dialogStartButton;
    private NPC _npc;

    private void Awake()
    {
        _dialogStartButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _dialogStartButton.onClick.AddListener(OnClickDialogButton);
    }

    private void OnDisable()
    {
        _menu.OnClickExitButton(_panel);
        _dialogStartButton.onClick.RemoveListener(OnClickDialogButton);
    }

    public void SetNPC(NPC npc)
    {
        _npc = npc;
    }

    private void OnClickDialogButton()
    {
        _menu.OnClickOpenButton(_panel);
        _dialogDisplay.SetNPC(_npc);
    }
}
