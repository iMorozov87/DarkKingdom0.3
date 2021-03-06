using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonDataConverter : MonoBehaviour
{
    private Dictionary<Type, Type> _savedData = new Dictionary<Type, Type>();

    public void Init()
    {
        _savedData.Add(typeof(Inventory), typeof(ListItemsData));
    }

    public string GetData(ISavable savable)
    {
        ISaveableStruct saveableStruct = savable.GetSaveData();
        string data = JsonUtility.ToJson(saveableStruct, true);
        return data;
    }

    public void SetData(string data, ILoadable loadable)
    {
        ISaveableStruct saveableStruct = null;
        switch (loadable)  
        {            
            case Inventory inventory:
                saveableStruct = JsonUtility.FromJson<ListItemsData>(data);           
                break;
            case Player player:
                saveableStruct = JsonUtility.FromJson<PlayerDataSave>(data);              
                break;
            case PlayerPositioner playerPositioner:
                saveableStruct = JsonUtility.FromJson<PlayerPositionData>(data);               
                break;
            case PlayerParametersEnhancer playerParametersEnhancer:
                saveableStruct = JsonUtility.FromJson<CharacterParametersData>(data);               
                break;
            case QuestsList questsList:
                saveableStruct = JsonUtility.FromJson<QuestsListData>(data);                
                break;
            default:
                Debug.Log("Error convert from Json");
                break;
        }
        loadable.SetSaveData(saveableStruct);
    }
}

