using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort
{
    private SOData _soData;
    private Sprite[] _sprites;
    private CalculateRandom _calculateRandom;
    private SetIDcount _setIDcount;
    public Sort(SOData soData, Sprite[] sprite, CalculateRandom calculateRandom, SetIDcount setIDcount)
    {
        _soData = soData;
        _sprites = sprite;
        _calculateRandom = calculateRandom;
        _setIDcount = setIDcount;
    }
    public void Find()
    {
        _calculateRandom.Update();
        for (int i = 0; i < _sprites.Length; i++)
        {
            _setIDcount.Update(i);
            for (int b = 0; b < i; b++)
            {
                while (_soData._IDcount[i] == _soData._IDcount[b])
                {
                    _calculateRandom.Update();
                    _setIDcount.Update(i);
                    b = 0;
                }
            }
            if(_soData._stateOfTheGame != 0 && _soData._sprites[_soData._IDcount[i]] == _soData._isolatedSprites[_soData._stateOfTheGame - 1])
            {
                _calculateRandom.Update();
                _setIDcount.Update(i);
            }
            if (_soData._stateOfTheGame != 0 && _soData._stateOfTheGame != 1 && _soData._sprites[_soData._IDcount[i]] == _soData._isolatedSprites[_soData._stateOfTheGame - 2])
            {
                _calculateRandom.Update();
                _setIDcount.Update(i);
            }
        }
    }
}
