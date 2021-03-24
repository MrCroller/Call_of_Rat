using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void Update()
    {
        var t = Quaternion.Euler(45, 45, 45);
        transform.rotation = t;
    }
}
