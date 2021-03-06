using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerParametrsDisplay : MonoBehaviour
{
    [SerializeField] private PlayerSpawner _playerSpawner;
    [SerializeField] private PlayerParametersView _parametrsViewTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private TMP_Text _pointsDisplay;

    private int _pointsImprovement;
    private PlayerParametersEnhancer _parametersEnchancer;
    private List<PlayerParametersView> _playerParametrsViews = new List<PlayerParametersView>();
    private List<PlayerParameterInt> _playerParametrs = new List<PlayerParameterInt>();

    private void Awake()
    {
        _parametersEnchancer = _playerSpawner.GetPlayer().GetComponent<PlayerParametersEnhancer>();
        _playerParametrs = CreateListPlayerParameters();
        _playerParametrsViews = CreateListParametersViews();
        SetParametersViews();
    }

    private void OnEnable()
    {
        _parametersEnchancer.PointsChanged += OnPointsChanged;
        _parametersEnchancer.PlayerEnchanced += SetParametersViews;
        foreach (var playerParametrs in _playerParametrsViews)
        {
            playerParametrs.OnBayClicked += OnParametersViewButtonClick;
        }
    }

    private void OnDisable()
    {
        foreach (var playerParametrs in _playerParametrsViews)
        {
            playerParametrs.OnBayClicked -= OnParametersViewButtonClick;
        }
        _parametersEnchancer.PointsChanged -= OnPointsChanged;
        _parametersEnchancer.PlayerEnchanced -= SetParametersViews;
    }

    private void OnPointsChanged()
    {
        _pointsImprovement = _parametersEnchancer.PointsImprovement;
        _pointsDisplay.text = _pointsImprovement.ToString();
        SetParametersViews();
    }

    private List<PlayerParameterInt> CreateListPlayerParameters()
    {
        List<PlayerParameterInt> playerParametrs = new List<PlayerParameterInt>();
        playerParametrs.Add((PlayerParameterInt)_parametersEnchancer.MaxHealth);
        playerParametrs.Add((PlayerParameterInt)_parametersEnchancer.Demage);
        return playerParametrs;
    }

    private List<PlayerParametersView> CreateListParametersViews()
    {
        List<PlayerParametersView> playerParametrsViews = new List<PlayerParametersView>();
        foreach (var playerParametr in _playerParametrs)
        {
            playerParametrsViews.Add(CreateParametersView(playerParametr));
        }
        return playerParametrsViews;
    }

    private PlayerParametersView CreateParametersView(PlayerParameterInt characterParameter)
    {
        PlayerParametersView newView = Instantiate(_parametrsViewTemplate, _container);
        newView.SetValue(characterParameter, _pointsImprovement); 
        return newView;
    }

    private void SetParametersViews()
    {
        for (int i = 0; i < _playerParametrsViews.Count; i++)
        {
            _playerParametrsViews[i].SetValue(_playerParametrs[i], _pointsImprovement);
        }
    }

    private void OnParametersViewButtonClick(PlayerParameterInt characterParameter)
    {
        _parametersEnchancer.PlayerEnchance(characterParameter);
        _parametersEnchancer.RemovePoints();
    }
}
