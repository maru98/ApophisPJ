using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    [SerializeField] Transform _cam;
    [SerializeField] Collider _sword;
    [SerializeField] GameObject _gameoverUI;
    Animator _ani;

    int HP = 2;
    int _coin = 0;

    private void Awake()
    {
        _ani = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(_cam.transform.forward.x, 0, _cam.transform.forward.z));
        float vX = Input.GetAxisRaw("Horizontal");
        float vZ = Input.GetAxisRaw("Vertical");
        float vY = GetComponent<Rigidbody>().velocity.y;
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        Vector3 v3 = forward * vZ + right * vX;
        float speed = 4.5f;
        if (Input.GetKey(KeyCode.LeftShift)) speed = 9f;
        Vector3 vYz = v3.normalized * speed;
        vYz.y += vY;

        _ani.SetFloat("AxisX", vX);
        _ani.SetFloat("AxisZ", vZ);
        _ani.SetFloat("MoveValue", speed > 4.5f ? 2f : 1f);



        GetComponent<Rigidbody>().velocity = vYz;
       
    }

    bool canHitted = true;
    public void Hitted()
    {
        if (!canHitted) return;
        HP--;
        if (HP < 0)
        {
            _gameoverUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            _ani.SetTrigger("Hitted");
        }
        canHitted = false;
        StartCoroutine(CoHittedCoolTime());
    }

    IEnumerator CoHittedCoolTime()
    {
        yield return new WaitForSeconds(1f);
        canHitted = true;
    }

    void EndAttack()
    {
        _sword.enabled = false;
    }

    public void AddCoin()
    {
        _coin++;

    }


}


