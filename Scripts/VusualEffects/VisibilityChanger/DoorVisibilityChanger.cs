using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVisibilityChanger : VisibilityChanger
{
    [SerializeField] private Door _door;

    private void OnEnable()
    {
        _door.Oppened += MakeInvisible;
        _door.Closed += MakeVisible;
    }

    private void OnDisable()
    {
        _door.Oppened -= MakeInvisible;
        _door.Closed -= MakeVisible;
    }
}
