using UnityEngine;

public class RotationFreezer : MonoBehaviour
{  
   [SerializeField] private MoveState[] _moveStates;

    private void OnEnable()
    {
        foreach (var moveState in _moveStates)
        {
            moveState.Flipped += OnFlipped;
        }       
    }

    private void OnDisable()
    {
        foreach (var moveState in _moveStates)
        {
            moveState.Flipped -= OnFlipped;
        }        
    }

    private void OnFlipped(Vector2 localScale)
    {
        transform.localScale = localScale;
    }
}
