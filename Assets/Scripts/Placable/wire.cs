using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class wire : MonoBehaviour
{
    private RaycastHit hit;
    private GameObject nextInnLine;
    private wire nextWire;
    private GameObject child;
    [SerializeField] public GameObject explosiveConnected;
    private Vector3 Backwards;
    
    private void Awake()
    {
        transform.position += transform.forward * 1f;
        foreach (var hit in Physics.BoxCastAll(transform.position, Vector3.one * 0.5f,-transform.forward, new Quaternion(0,0,0,0), 0.6f))
        {
            if (hit.collider == null) return;
            if (hit.collider.gameObject == this) return;
            if (hit.collider.gameObject.CompareTag("explosive"))
            {
                explosiveConnected = hit.collider.gameObject;
                print("explosive spotted");
            }
            if (hit.collider.gameObject.CompareTag("Wire"))
            {
                nextInnLine = hit.collider.gameObject;
                nextWire = nextInnLine.GetComponent<wire>();
                explosiveConnected = nextWire.explosiveConnected;
            }
        }

        transform.position += transform.up * -0.5f;

        /*Physics.RaycastAll(transform.position,)(transform.position, -transform.forward, out hit, 2f);
        if (hit.collider == null || hit.collider.gameObject == this)
        {
            print("didn't find nothing so self Destroy");
        }
        if (hit.collider.gameObject.CompareTag("explosive"))
        {
            explosiveConnected = hit.collider.gameObject;
            print("explosive spotted");
        }
        else if (hit.collider.gameObject.CompareTag("Wire"))
        {
            nextInnLine = hit.collider.gameObject;
            nextReceiver = nextInnLine.GetComponent<receiver>();
            explosiveConnected = nextInnLine.GetComponent<wire>().explosiveConnected;
        }*/
        if (nextInnLine != null) print("I am connected");
        else print("didn't find nothing");  
    }
  
    public void called()
    {
        if (nextInnLine != null) nextWire.called();
        Destroy(this, 0.2f);
    }
}
