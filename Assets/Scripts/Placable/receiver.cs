using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class receiver : MonoBehaviour
{
    private wire myWire;

    private void Awake()
    {
        myWire = GetComponent<wire>();
    }

    public void call()
    {
        myWire.called();
    }
}
