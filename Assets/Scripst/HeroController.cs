using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    Animator _ani;
    float _moveValue = 0;

    private void Awake()
    {
        _ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //HeroSetAni();
        HeroDirAni();
    }

    void HeroDirAni()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().velocity = new Vector3(dirX, 0, dirZ) * 3;

        _ani.SetFloat("AxisX", dirX);
        _ani.SetFloat("AxisZ", dirZ);
    }

    void HeroSetAni()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _moveValue += Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveValue += Time.deltaTime * 2;
            }
        }
        else
        {
            _moveValue -= Time.deltaTime;
        }
        if (_moveValue < 0) _moveValue = 0;
        if (_moveValue > 1) _moveValue = 1;
        _ani.SetFloat("MoveValue", _moveValue);
    }
}
