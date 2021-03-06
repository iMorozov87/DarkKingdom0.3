using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDeleter : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private Player _player;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private PlayerParametersEnhancer _playerEnchancer;
    [SerializeField] private PlayerPositioner _playerPositioner;
    [SerializeField] private QuestsList _questsList;

    private List<ISavable> _deletableSaves;
    private string _saveFolderPatch;

    private void OnEnable()
    {
        _mainMenu.NewGameStarted += DeleteAllSaves;
    }

    private void OnDisable()
    {
        _mainMenu.NewGameStarted -= DeleteAllSaves;
    }

    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _saveFolderPatch = Application.persistentDataPath;
#else
        _saveFolderPatch = Application.dataPath;
#endif
        _deletableSaves = CreateListDeletableSave();   
    }

    private List<ISavable> CreateListDeletableSave()
    {
        List<ISavable> deletableSaves = new List<ISavable>();
        deletableSaves.Add(_player);
        deletableSaves.Add(_inventory);
        deletableSaves.Add(_playerEnchancer);
        deletableSaves.Add(_playerPositioner);
        deletableSaves.Add(_questsList);
        return deletableSaves;
    }

    private void DeleteAllSaves()
    {
        foreach (var deletableSaves in _deletableSaves)
        {
            try
            {
                string savePatchInventory = Path.Combine(_saveFolderPatch, deletableSaves.ToString() + ".txt");
                File.Delete(savePatchInventory);
            }
            catch
            {
                Debug.Log("Delete error" + deletableSaves.ToString() + ".txt");
            }
        }
    }
}
