using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerParameterInt : CharacterParameterInt
{
    public override void IncreaseLevel()
    {
        ++Level;
        SetCurrentValue();
    }

    public void SetSaveData(CharacterParameterData parameterData)
    {
        Name = parameterData.Name;
        StartValue = parameterData.StartValue;
        CurrentValue = parameterData.CurrentValue;
        DeltaValue = parameterData.DeltaValue;
        Level = parameterData.Level;
    }
}


