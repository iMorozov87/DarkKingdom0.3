using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerParametersView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _currentValue;
    [SerializeField] private Button _bayButton;

    private PlayerParameterInt _characterParameter;

    public event UnityAction<PlayerParameterInt> OnBayClicked;

    private void OnEnable()
    {
        _bayButton.onClick.AddListener(OnBayButtonClick);
    }

    private void OnDisable()
    {
        _bayButton.onClick.RemoveListener(OnBayButtonClick);
    }

    public void SetValue(PlayerParameterInt characterParameter, int pointsImprovement)
    {
        _characterParameter = characterParameter;
        _label.text = characterParameter.Name;
        _currentValue.text = characterParameter.CurrentValue.ToString();
        if (pointsImprovement <= 0)
            _bayButton.interactable = false;
        else
            _bayButton.interactable = true;        
    }

    private void OnBayButtonClick()
    {        
        OnBayClicked?.Invoke(_characterParameter);
    }    
}