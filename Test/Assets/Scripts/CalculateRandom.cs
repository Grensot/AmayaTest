using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateRandom 
{
    private SOData _soData;
    private Sprite[] _sprites;
    public CalculateRandom(SOData soData, Sprite[] sprites)
    {
        _soData = soData;
        _sprites = sprites;
    }
    public void Update()
    {
       _soData._randomNumber = Random.Range(0, _sprites.Length);
    }
}
