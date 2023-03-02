using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    Animator _ani;
    float _moveValue = 0;
    float _axisValue = 0;

    private void Awake()
    {
        _ani= GetComponent<Animator>(); 
    }

     void Update()
    {
        //HeroSetAni();
        HeroDirAni();
    }

    void HeroDirAni()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        

        GetComponent<Rigidbody>().velocity = new Vector3(dirX, 0, dirY).normalized* 3;

        _ani.SetFloat("AxisX", dirX);
        _ani.SetFloat("AxisY", dirY);
        _ani.SetFloat("AniValue", Mathf.Abs(dirX)+ Mathf.Abs(dirY));
    }
    void HeroSetAni()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _moveValue += Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveValue -= Time.deltaTime * 2;
            }
        }
        else
        {
            _moveValue -= Time.deltaTime;
        }
        if (_moveValue < 0) _moveValue = 0;
        if(_moveValue > 1 ) _moveValue = 1;
        _ani.SetFloat("MoveValue", _moveValue);
    }
}
