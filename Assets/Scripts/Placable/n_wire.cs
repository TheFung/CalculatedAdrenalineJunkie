using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n_wire : MonoBehaviour
{
    private Transform parrent;
    private void Start()
    {
        print(transform.parent.name);
        transform.position += Vector3.down * 0.5f;
        transform.position += transform.forward;
        GetComponentInParent<ExplosiveCharge>().children.Add(transform);
    }
}
