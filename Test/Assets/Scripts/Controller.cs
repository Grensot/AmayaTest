using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller: MonoBehaviour
{
    [SerializeField]
    private GameObject _particles;
    [SerializeField]
    private SOData _soData;
    [SerializeField]
    private Sprite _retry;
    private Animator _anim;
    private void OnMouseDown()
    {
        var _sprite = this.GetComponent<SpriteRenderer>();
        _anim = this.GetComponent<Animator>();
        if (_sprite.sprite == _soData._correctSprite)
        {
            Debug.Log("+");
            _particles.SetActive(true);
            Invoke("NextStage", 2);
            _anim.SetBool("IsBounce", true);
            StopAnim();
        }
        else if (_sprite.sprite == _retry)
        {
            _soData._stateOfTheGame = 0;
            _soData._end = true;
        }
        else
        {
            Debug.Log("-");
            _anim.SetBool("IsShaking", true);
            StopAnim();
        }
    }
    public void NextStage()
    {
        _soData._stateOfTheGame++;
        _soData._destroygm = true;
    }
    public IEnumerator WaitandStop()
    {
        yield return new WaitForSeconds(0.76f);
        Debug.Log("123123");
        _anim.SetBool("IsShaking", false);
       // _anim.SetBool("IsBounce", false);
    }
    public void StopAnim()
    {
        StartCoroutine("WaitandStop");
    }

}
