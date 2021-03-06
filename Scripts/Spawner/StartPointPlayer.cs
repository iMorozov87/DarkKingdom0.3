using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StartPoint")]
public class StartPointPlayer : ScriptableObject
{
    public Vector3 Point;
    public Vector3 LocalScale;
    public Player PlayerTemlate;    
}
