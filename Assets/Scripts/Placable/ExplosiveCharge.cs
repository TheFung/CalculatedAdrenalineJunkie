using System;
using UnityEngine;

public class ExplosiveCharge : MonoBehaviour
{
    public bool _hasExploded = false;
    [SerializeField] private AnimationCurve scale;
    [SerializeField] private AnimationCurve hight;
    private Vector3 startPos;
    private float _timer;
    private void Awake()
    {
        ExplosiveChargeController._charges.Add(transform);
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
}
