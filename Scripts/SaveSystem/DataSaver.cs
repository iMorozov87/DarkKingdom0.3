using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(JsonDataConverter))]
public class DataSaver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private PlayerParametersEnhancer _playerEnchancer;
    [SerializeField] private PlayerPositioner _playerPositioner;
    [Multiline(10)] public string _dataSave;

    private JsonDataConverter _dataConverter;
    private QuestsList _questsList;
    private QuestJournal _questJournal;
    private string _saveFolderPatch;
    private string _fileName;

    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _saveFolderPatch = Application.persistentDataPath;
#else
        _saveFolderPatch = Application.dataPath;
#endif
        _questsList = FindObjectOfType<QuestsList>();
        _dataConverter = GetComponent<JsonDataConverter>();        
    }

    public void SetQuestJornal(QuestJournal questJournal)
    {
        _questJournal = questJournal;
    }

    private void Start()
    {
        LoadDataSave();
    }

    public void GetDataSave()
    {        
        GetDataSave(_player);
        GetDataSave(_inventory);
        GetDataSave(_questsList);
        GetDataSave(_playerEnchancer);
        GetDataSave(_playerPositioner);
    }

    private void GetDataSave(ISavable savable)
    {
        try
        {
            _dataSave = _dataConverter.GetData(savable);            
            string savePatch = Path.Combine(_saveFolderPatch, savable.ToString() + ".txt");
            File.WriteAllText(savePatch, _dataSave);
        }
        catch
        {
            Debug.Log("Error Save " + savable.ToString());
        }
    }

    private void LoadDataSave()
    {
        SetDataSave(_playerPositioner);
        SetDataSave(_inventory);
        SetDataSave(_questsList);
        SetDataSave(_playerEnchancer);
        SetDataSave(_player);
    }

    private void SetDataSave(ILoadable loadable)
    {
        try
        {
            string savePatch = Path.Combine(_saveFolderPatch, loadable.ToString() + ".txt");
            _dataSave = File.ReadAllText(savePatch);
            _dataConverter.SetData(_dataSave, loadable);
        }
        catch
        {
            Debug.Log("Error Load " + loadable.ToString());
        }
    }    
}

