using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _loadGameButton;
    [SerializeField] private Button _exitGameButton;

    public event UnityAction NewGameStarted;

    private void OnEnable()
    {
        _newGameButton.onClick.AddListener(OnNewGameButtonClick);
        _loadGameButton.onClick.AddListener(OnLoadGameButtonClick);
        _exitGameButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _newGameButton.onClick.RemoveListener(OnNewGameButtonClick);
        _loadGameButton.onClick.RemoveListener(OnLoadGameButtonClick);
        _exitGameButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnNewGameButtonClick()
    {
        StartNewGame();
    }
    private void OnLoadGameButtonClick()
    {
        LoadScene();
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void LoadScene()
    {
        try
        {
            int sceneNumber = PlayerPrefs.GetInt("sceneNumber");
            SceneManager.LoadScene(sceneNumber);
        }
        catch
        {
            Debug.Log("Error Scen Load");
        }
    }

    private void StartNewGame()
    {
        NewGameStarted?.Invoke();
        int sceneNumber = 1;
        PlayerPrefs.SetInt("sceneNumber", sceneNumber);
        SceneManager.LoadScene(sceneNumber);  
    }
}
