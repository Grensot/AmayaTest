using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIDcount
{
    private SOData _soData;
    public SetIDcount(SOData soData)
    {
        _soData = soData;
    }
    public void Update(int id)
    {
       _soData._IDcount[id] = _soData._randomNumber;
    }
}
