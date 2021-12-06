using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCorrectAnswer
{
    private SOData _soData;
    private CalculateRandom _calculateRandom;
    public FindCorrectAnswer(SOData soData, CalculateRandom calculateRandom)
    {
        _soData = soData;
        _calculateRandom = calculateRandom;
    }
    public void FindAnswer()
    {
        _calculateRandom.Update();
        while((_soData._randomNumber >= 3 && _soData._stateOfTheGame == 0) || (_soData._randomNumber >= 6 && _soData._stateOfTheGame == 1) || (_soData._randomNumber >= 9 && _soData._stateOfTheGame == 2))
        {
            _calculateRandom.Update();
        }
        _soData._correctSprite = _soData._sprites[_soData._IDcount[_soData._randomNumber]];
        if (_soData._stateOfTheGame <= 2)
        _soData._isolatedSprites[_soData._stateOfTheGame] = _soData._correctSprite;
    }
}
