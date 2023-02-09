using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameUI : MonoBehaviour
{
    // Start is called before the first frame update
    float HP = 0;
    
    void Start()
    {
        HP -= (10 / Mathf.Pow(600, 2.5f)) * Mathf.Pow(9, 2.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
