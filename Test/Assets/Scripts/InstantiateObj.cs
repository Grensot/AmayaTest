using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateObj : MonoBehaviour
{
    [SerializeField]
    private SOData _soData;
    [SerializeField]
    private GameObject _go;
    [SerializeField]
    private GameObject[] _obj;
    [SerializeField]
    private int count;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private GameObject _menu;
    [SerializeField]
    private GameObject _retry;
    [SerializeField]
    private Animator[] _anim;
    private FadeInOut _fadeInOut;
    private float y;
    private float x;
    private bool _fadeOut;
    private bool _fadeIn;
    public void Start()
    {
        _soData._end = true;
        count = _soData._count;
        _fadeInOut = new FadeInOut();
        _fadeInOut.Start(_menu);
    }
    private void Update()
    {
        CreateTiles();
        if (_fadeIn)
        {
            StartFadingIn();
            _fadeIn = false;
        }
        if (_fadeOut)
        {
            StartFadingOut();
            _fadeOut = false;
        }
    }
    public void CreateTiles()
    {
        if (_soData._stateOfTheGame == 0)
        {
            if (_soData._end)
            {
                _retry.SetActive(false);
                _fadeOut = true;
                _soData._end = false;
            }
            while (count < 3)
            {
                y = 0;
                x = 0;
                CreateObj();
                _anim[count] = _obj[count].GetComponent<Animator>();
                _anim[count].SetBool("IsBounce", true);
                StopAnim();
                count++;
            }
            _text.text = "Find " + _soData._correctSprite.name;
            _soData._destroygm = false;
        }
        else if (_soData._stateOfTheGame == 1)
        {
            while(count !=0 && _soData._destroygm)
            DestroyGM();
            while (count < 3)
            {
                y = 2.5f;
                x = 0;
                CreateObj();
                count++;
            }
            while (count >= 3 && count < 6)
            {
                y = -2.5f;
                x = 12;
                CreateObj();
                count++;
            }
            _soData._destroygm = false;
            _text.text = "Find " + _soData._correctSprite.name;
        }
        else if (_soData._stateOfTheGame == 2)
        {
            while (count != 0 && _soData._destroygm)
            DestroyGM();
            while (count < 3)
            {
                y = 3.5f;
                x = 0;
                CreateObj();
                count++;
            }
            while (count >= 3 && count < 6)
            {
                y = 0;
                x = 12;
                CreateObj();
                count++;
            }
            while (count >= 6 && count < 9)
            {
                y = -3.5f;
                x = 24;
                CreateObj();
                count++;
            }
            _soData._destroygm = false;
            _text.text = "Find " + _soData._correctSprite.name;
            _soData._end = true;
        }
        else if (_soData._stateOfTheGame >= 3 && _soData._end)
        {
            while (count != 0 && _soData._destroygm)
            DestroyGM();
            _fadeIn = true;
            _retry.SetActive(true);
            _soData._end = false;
        }
    }
    public void CreateObj()
    {
        _obj[count] = Instantiate(_go, new Vector3(count * 4.0F - 4 - x, y, 0), Quaternion.identity);
        var Sprite = _obj[count].GetComponent<SpriteRenderer>();
        Sprite.sprite = _soData._sprites[_soData._IDcount[count]];
    }
    public void DestroyGM()
    {
        if (count != -1)
        {
            count--;
            Destroy(_obj[count]);
        }
    }
    public IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1.5; f += 0.05f)
        {
            _fadeInOut.Fade(f);
            yield return new WaitForSeconds(0.05f);
        }
    }
    public IEnumerator FadeOut()
    {
        for (float f = 1.3f; f >= -0.05; f -= 0.05f)
        {
            _fadeInOut.Fade(f);
            yield return new WaitForSeconds(0.05f);
        }
    }
    public IEnumerator WaitandStop()
    {
        yield return new WaitForSeconds(0.76f);
        _anim[0].SetBool("IsBounce", false);
        _anim[1].SetBool("IsBounce", false);
        _anim[2].SetBool("IsBounce", false);
    }
    public void StartFadingIn()
    {
        StartCoroutine("FadeIn");
    }
    public void StartFadingOut()
    {
        StartCoroutine("FadeOut");
    }
    public void StopAnim()
    {
        StartCoroutine("WaitandStop");
    }
}