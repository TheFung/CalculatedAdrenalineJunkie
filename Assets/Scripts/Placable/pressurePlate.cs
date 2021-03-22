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
    private GameObject _explosive;
    private float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        foreach (var playerSearch in Physics.OverlapBox(transform.position, Vector3.one * 0.1f))
        {
            if (playerSearch.gameObject.CompareTag("Player") && timer >= 0.2f)
            {
                print("deadasspressure plate down");
                _wire.called();
                //_explosive
                Destroy(this, 0.2f);
            }
        }
    }

    private void Awake()
    {
        foreach (var wire in Physics.OverlapBox(transform.position, Vector3.one * bulshitmcbuslshitgeeethisfuckereintworking, new Quaternion()))
        {
            if (wire.CompareTag("Wire"))
            {
                Vector3 directionToWire = wire.transform.position - transform.position;
                float dSqrToTarget = directionToWire.sqrMagnitude;
                if (dSqrToTarget <= enbotherlevelofbullshitcode) closestWire = wire.gameObject;
            }
        }
        if (closestWire != null)
        {
            _wire = closestWire.GetComponent<wire>();
            _explosive = _wire.explosiveConnected;
        }
    }

}
