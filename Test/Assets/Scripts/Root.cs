using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _sprites;
    [SerializeField]
    private SOData _soData;
    private CalculateRandom _calculateRandom;
    private SetIDcount _setIDcount;
    private Sort _sort;
    private SetNull _setNull;
    private FindCorrectAnswer _findCorrectAnswer;
    private void Start()
    {
        _calculateRandom = new CalculateRandom(_soData, _sprites);
        _setIDcount = new SetIDcount(_soData);
        _sort = new Sort(_soData, _sprites, _calculateRandom, _setIDcount);
        _setNull = new SetNull(_soData);
        _findCorrectAnswer = new FindCorrectAnswer(_soData, _calculateRandom);
        _setNull.Start();
        _sort.Find();
        _findCorrectAnswer.FindAnswer();
    }
    private void Update()
    {
        if (_soData._destroygm)
        {
            _sort.Find();
            _findCorrectAnswer.FindAnswer();
        }
    }
}
