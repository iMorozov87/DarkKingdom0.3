using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleInstanceUI : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private ParticleSystem _particleStars;
    [SerializeField] private Camera _camera;

    private void OnEnable()
    {
        _button.onClick.AddListener(ParticlePlay);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ParticlePlay);
    }

    private void ParticlePlay()
    {  Vector3 position = Input.mousePosition;  
        Vector3 effectPosition = _camera.ScreenToWorldPoint(new Vector3(position.x, position.y, 10));
        Instantiate(_particleStars, effectPosition, Quaternion.identity);        
    }
}
