using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    [SerializeField] private int _scenesNumber;
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private StartPointPlayer _startPointPlayer;
    [SerializeField] private Vector3 _startPointNextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _startPointPlayer.Point = _startPointNextLevel;
            _startPointPlayer.LocalScale = player.transform.localScale;
            player.GetComponent<PlayerPositioner>().SetStartPoint(_startPointPlayer);
            player.GetComponent<DataSaver>().GetDataSave();
            PlayerPrefs.SetInt("sceneNumber", _scenesNumber);
            SceneManager.LoadScene(_scenesNumber);
        }
    }
}
