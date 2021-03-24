using System.Runtime.CompilerServices;
using NUnit.Framework.Constraints;
using UnityEngine;
using Random = UnityEngine.Random;

public class woobly_effect : MonoBehaviour
{
    [SerializeField] public AnimationCurve scaleCurveInn;
    [SerializeField] private AnimationCurve[] scaleCurves;
    [SerializeField] public bool _steppedOn;
    [SerializeField] public AnimationCurve ExplotionCurve;
    [SerializeField] public float minDistanceFromExplotion;
    public bool canrun = false;
    private float _timer = 0f;
    private float _distanceFromExplotion;
    private float _explotionTime = 2f;
    private float _explotionEffekt;
    private bool _curentlyExploding;
    private bool _hasFormed = false;
    public int i;
    private bool _isExploding = false;
    public float distance;
    void Update()
    {
        _explotionEffekt = ExplotionCurve.Evaluate(_explotionTime);
        _timer += 1 * Time.deltaTime;
        GetExplosiveData();
        if (!_hasFormed)
        {
            AnimateTheCurves(scaleCurveInn);
            i = Random.Range(0, 1);
        }
        
        if (transform.localScale.x >= 0.9f && !_steppedOn)
        {
            _hasFormed = true;
        }
        
        if (transform.localScale.x >= 0.9f && !_steppedOn)
        {
            _timer = 0.01f; 
            i = Random.Range(0, 2);
            transform.localScale =  new Vector3(0.0f,0.0f, 0.0f);
            canrun = true;
        }
        
        if (canrun)
        {
          AnimateTheCurves(scaleCurves[i]);
        }

        if (_steppedOn)
        {
            transform.localScale = Vector3.one;
        }

        if (_isExploding)
        {
            _explotionTime = 0f;
            print("I exploded in woobly");
            _isExploding = false;
        }
    }
    private void FixedUpdate()
    {
        if(_explotionTime < 2) _explotionTime += 0.2f;
    }
    private void AnimateTheCurves(AnimationCurve curve)
    {
        transform.localScale = Vector3.one * (curve.Evaluate(_timer) + _explotionEffekt);
    }



    private void GetExplosiveData()
    {
        foreach (var t in ExplosiveChargeController._charges)
        {
            if (t == null) return;
            if (t.GetComponent<ExplosiveCharge>()._hasExploded)
            {
                distance = Vector3.Distance(transform.parent.position, t.transform.position);
                if (distance < minDistanceFromExplotion && _explotionTime >= 2f) _isExploding = true;
            }
        }
    }
}