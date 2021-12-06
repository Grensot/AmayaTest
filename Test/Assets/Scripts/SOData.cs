using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SOData", order = 1)]
public class SOData : ScriptableObject
{
    public int _randomNumber;
    public int[] _IDcount;
    public int _count;
    public int _stateOfTheGame;
    public Sprite[] _sprites;
    public Sprite _correctSprite;
    public bool _destroygm;
    public bool _end = true;
    public Sprite[] _isolatedSprites;
}
