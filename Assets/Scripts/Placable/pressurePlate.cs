using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    private RaycastHit wire_hit;
    [SerializeField] private float bulshitmcbuslshitgeeethisfuckereintworking;
    [SerializeField] private float enbotherlevelofbullshitcode;
    private List<GameObject> wirelist;
    private float closestDistanceSqr = Mathf.Infinity;
    private GameObject closestWire;
    private wire _wire;
    private Transform _explosive;
    private float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        foreach (var playerSearch in Physics.OverlapBox(transform.position, Vector3.one * 0.1f))
        {
            if (playerSearch.gameObject.CompareTag("Player") && timer >= 0.2f)
            {
                print("deadasspressure plate down");
                _explosive.GetComponent<ExplosiveCharge>().calledByPressurePlate();
            }
        }
    }
    private void Start()
    {
        _explosive = transform.parent;
        _explosive.GetComponent<ExplosiveCharge>().children.Add(transform);
    }

}
