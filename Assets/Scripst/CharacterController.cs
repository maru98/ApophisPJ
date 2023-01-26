using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float _speed;
    Animator _ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    enum EMoveType
    {
        Idle,
        Right,
        forwrd,
        back,
        Left,
    }
    void move()
    {
        Vector3 v3 = Vector3.zero;
        bool isIdle = false;
        if(Input.GetKey("w"))
        {
            v3 += Vector3.forward * Time.deltaTime * _speed;
            _ani.SetInteger("moveDirection", (int)EMoveType.forwrd);
        }
        if(Input.GetKey("a"))
        {
            v3 += Vector3.left * Time.deltaTime * _speed;
            _ani.SetInteger("moveDirection", (int)EMoveType.Left);
        }

        if(Input.GetKey("d"))
        {
            v3 += Vector3.right * Time.deltaTime * _speed;
            _ani.SetInteger("moveDirection", (int)EMoveType.Right);
        }
        
        if(Input.GetKey("s"))
        {
            v3 += Vector3.back * Time.deltaTime * _speed;
            _ani.SetInteger("moveDirection", (int)EMoveType.back);
        }
        if(v3 != Vector3.zero) { transform.Translate(v3); }
        
    }

}
