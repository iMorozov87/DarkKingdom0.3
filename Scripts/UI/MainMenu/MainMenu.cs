using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.Events;

public class MainMenu : Menu
{
    [SerializeField] private Button _newGameButton;

    public event UnityAction NewGameStarted;

    protected override void OnEnable()
    {
        base.OnEnable();
        _newGameButton.onClick.AddListener(OnNewGameButtonClick);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _newGameButton.onClick.RemoveListener(OnNewGameButtonClick);
    }

    private void OnNewGameButtonClick()
    {
        StartNewGame();
    }  

    private void StartNewGame()
    {
        NewGameStarted?.Invoke();
        int sceneNumber = 1;
        PlayerPrefs.SetInt("sceneNumber", sceneNumber);
        SceneManager.LoadScene(sceneNumber);  
    }
}
