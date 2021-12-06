using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNull
{
    private SOData _soData;
    public SetNull(SOData soData)
    {
        _soData = soData;
    }
    public void Start()
    {
        _soData._stateOfTheGame = 0;
        _soData._randomNumber = 0;
        _soData._count = 0;
        for (int i = 0; i < _soData._IDcount.Length; i++)
        {
            _soData._IDcount[i] = 0;
        }
    }
}
