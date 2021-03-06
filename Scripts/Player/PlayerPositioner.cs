using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositioner : MonoBehaviour, ISavable, ILoadable
{
    [SerializeField] private Player _player;

    private StartPointPlayer _startPointPlayer;

    public void SetStartPoint(StartPointPlayer startPointPlayer)
    {
        _startPointPlayer = startPointPlayer;
    }
    
    public ISaveableStruct GetSaveData()
    {
        PlayerPositionData playerPositionData = new PlayerPositionData(_startPointPlayer.Point, _player);        
        return playerPositionData;
    }
    
    public void SetSaveData(ISaveableStruct saveableStruct)
    {
        if (saveableStruct is PlayerPositionData playerPositionData)
        {
            _player.transform.position = playerPositionData.Position;
            _player.GetComponent<PlayerMover>().SetDirection(playerPositionData.LocalScale);
        }
    }
}

[System.Serializable]
public struct PlayerPositionData : ISaveableStruct
{
    public Vector3 Position;
    public Vector3 LocalScale;

    public PlayerPositionData(Vector3 position, Player player)
    {
        Position = position;
        LocalScale = player.transform.localScale;
    }
}

