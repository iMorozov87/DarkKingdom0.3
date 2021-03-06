using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private StartPointPlayer _startPointPlayer;
    [SerializeField] private QuestJournal _questJournal;
     
    private Player _player;
    private bool _isSpawned = false;

    public Player GetPlayer()
    {
        if(_player == null)
        {
            if (_startPointPlayer.Point == null)
            {
                _startPointPlayer.Point = transform.position;
                _startPointPlayer.LocalScale = transform.localScale;
            }
            _player = Instantiate(_startPointPlayer.PlayerTemlate, _startPointPlayer.Point, Quaternion.identity);
            _player.transform.localScale = _startPointPlayer.LocalScale;
            _player.GetComponent<DataSaver>().SetQuestJornal(_questJournal);
            _isSpawned = true;
        }
        return _player;
    }
}
