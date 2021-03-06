using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterParameterInt : CharacterParameter<int>
{
    public override void IncreaseLevel()
    {
        SetCurrentValue();
    }

    protected override void SetCurrentValue()
    {
        int offset = 1;
        if (Level > 0)
            CurrentValue = StartValue + (DeltaValue * (Level - offset));
    }
}
