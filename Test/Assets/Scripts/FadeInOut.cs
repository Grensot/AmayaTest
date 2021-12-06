using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut
{
    private Color _color;
    private SpriteRenderer _rend;
    public void Start(GameObject obj)
    {
        _rend = obj.GetComponent<SpriteRenderer>();
        _color = _rend.material.color;
        _color.a = 0f;
        _rend.material.color = _color;
    }
    public void Fade(float f)
    {
        _color = _rend.material.color;
        _color.a = f;
        _rend.material.color = _color;
    }
}
