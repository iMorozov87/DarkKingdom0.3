using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] protected Button LoadGameButton;
    [SerializeField] protected Button ExitGameButton;

    protected virtual void OnEnable()
    {
        LoadGameButton.onClick.AddListener(OnLoadGameButtonClick);
        ExitGameButton.onClick.AddListener(OnExitButtonClick);
    }

    protected virtual void OnDisable()
    {
        LoadGameButton.onClick.RemoveListener(OnLoadGameButtonClick);
        ExitGameButton.onClick.RemoveListener(OnExitButtonClick);
    }

    protected void OnLoadGameButtonClick()
    {
        LoadScene();
    }

    protected void OnExitButtonClick()
    {
        Application.Quit();
    }

    protected void LoadScene()
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
}
