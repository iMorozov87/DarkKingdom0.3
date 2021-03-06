using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class CharacterParameter<T> 
{
    public string Name;
    public T StartValue;
    public T CurrentValue;
    public T DeltaValue;
    public int Level;

    public abstract void IncreaseLevel();

    protected  abstract void SetCurrentValue();
}


