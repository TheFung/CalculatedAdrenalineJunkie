using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using PlayerMK2;
using UnityEngine;

public class ExplosiveCharge : MonoBehaviour
{
    public bool _hasExploded = false;
    public List<Transform> children;
    [SerializeField] private AnimationCurve scale;
    [SerializeField] private AnimationCurve hight;
    private GameObject _player;
    private Vector3 startPos;
    private float _timer;
    private knockBack _knockBack;
    private void Awake()
    {
        ExplosiveChargeController._charges.Add(transform);
        _player = GameObject.Find("PlayerMK2");
        _player.GetComponent<placeExplosive>().ex = transform;
    }
    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        if(_timer <= 1f) _timer += Time.deltaTime * 3f;
        transform.position = startPos + new Vector3(0, hight.Evaluate(_timer), 0);
        transform.localScale = Vector3.one * scale.Evaluate(_timer);
    }

    public void calledByPressurePlate()
    {
        
        _hasExploded = true;
        _knockBack = _player.transform.GetComponent<knockBack>();
        _knockBack.KnockBack(gameObject.transform);
        /*foreach (var child in children)
        {
            child.GetComponent<selfDestruck>().SelfDestroy();
        }
        */
        print("boom!");
        //ExplosiveChargeController._charges.Remove(transform);
        Destroy(gameObject, 0.2f);
    }
}
