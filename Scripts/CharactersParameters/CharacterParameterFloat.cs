using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterParameterFloat : CharacterParameter<float>
{
    public override void IncreaseLevel()
    {
        Level++;
        CurrentValue = StartValue + (DeltaValue * Level);
    }

    protected override void SetCurrentValue()
    {
        throw new System.NotImplementedException();
    }
}
