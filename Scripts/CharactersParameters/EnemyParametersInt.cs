using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyParametersInt : CharacterParameter<int>
{
    private int _gainFactor;

    public override void IncreaseLevel()
    {
        SetCurrentValue();
    }

    protected override void SetCurrentValue()
    {
        int offset = 1;
        _gainFactor = GetGainFactor();
        if (Level > 0)
            CurrentValue = StartValue + (DeltaValue * (Level - offset) * _gainFactor);          
    }

    private int GetGainFactor()
    {
        int gainFactor = 1;
        int numberLevelsToGain = 5;
        gainFactor += Level / numberLevelsToGain;
        return gainFactor;
    }
}
