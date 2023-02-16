using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Option : MonoBehaviour
{
    [SerializeField] GameObject _opton;
    [SerializeField] GameObject _soundoption;
    [SerializeField] GameObject _keyoption;
    [SerializeField] GameObject _mouseoption;


    public void OpTion()
    {
        Debug.Log("옵션버튼 입력");

        _opton.SetActive(true);
        Time.timeScale = 0;

    }
    public void KeyOption()
    {
        _keyoption.SetActive(true);
    }

    public void SoundOption()
    {
        _soundoption.SetActive(true);

    }
    public void MouseOption()
    {
        _mouseoption.SetActive(true);
    }
}