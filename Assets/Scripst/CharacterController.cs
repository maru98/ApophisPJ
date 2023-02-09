using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float _speed;
    Animator _ani;
    float _Hp = 0;
    float _time;
    // Start is called before the first frame update
    void Start()
    {
        _ani= GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    enum EMoveType
    {
        Idle,
        RunForward,
        RunLeft,
        RunRight,
        RunBackwardRight,
    }
    void move()
    {
        Vector3 v3 = Vector3.zero;
        bool isIdle = false;
        if(Input.GetKey("w"))
        {
            v3 += Vector3.forward * Time.deltaTime * _speed;
            _ani.SetInteger("Movement", (int)EMoveType.RunForward);
        }
        if(Input.GetKey("a"))
        {
            v3 += Vector3.left * Time.deltaTime * _speed;
            _ani.SetInteger("Movement", (int)EMoveType.RunLeft);
        }

        if(Input.GetKey("d"))
        {
            v3 += Vector3.right * Time.deltaTime * _speed;
            _ani.SetInteger("Movement", (int)EMoveType.RunRight);
        }
        
        if(Input.GetKey("s"))
        {
            v3 += Vector3.back * Time.deltaTime * _speed;
            _ani.SetInteger("Movement", (int)EMoveType.RunBackwardRight);
        }
        if(v3 != Vector3.zero) transform.Translate(v3);
        else
        {
            _ani.SetInteger("moveDirection", 0);
        }

    }

}
