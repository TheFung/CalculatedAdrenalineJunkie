using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using PlayerMK2;
using UnityEngine;

public class detector : MonoBehaviour
{
    private knockBack _knockBack;
    [SerializeField] private List<Transform> collitionRangeList;
    private void Start()
    {
        _knockBack = transform.GetComponentInParent<knockBack>();
        collitionRangeList = new List<Transform>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("Wire")) return;
        print(collision.transform.name + "I collided with");
        collitionRangeList.Add(collision.transform);
    }
    private void OnCollisionExit(Collision collision) => collitionRangeList.Remove(collision.transform);
    private void Update()
    {
        _knockBack.collided = collitionRangeList.Count != 0;
        foreach (var i in collitionRangeList)
        {
            print(i.name + "in Collision list");
        }
    }
}
