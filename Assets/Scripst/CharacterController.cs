using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 10f;
    public float jmpHeight = 3f;
    public float dash = 5f;
     void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }


     void Update()
    {
          Input.GetAxis("");
    }
    //[SerializeField] float _speed;
    //Animator _ani;
    //float _Hp = 0;
    //float _time;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    _ani= GetComponent<Animator>();

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    move();
    //}

    //enum EMoveType
    //{
    //    Idle,
    //    RunForward,
    //    RunLeft,
    //    RunRight,
    //    RunBackwardRight,
    //}
    //private void move()
    //{
    //  if(R)

    //}

}
