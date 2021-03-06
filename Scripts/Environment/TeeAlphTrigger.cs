using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeeAlphTrigger : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Color _basicColor;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _basicColor = _spriteRenderer.color;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Color newColor = _spriteRenderer.color;
            newColor.a = 0.3F;
            _spriteRenderer.color = newColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _spriteRenderer.color = _basicColor;
        }
    }
}
