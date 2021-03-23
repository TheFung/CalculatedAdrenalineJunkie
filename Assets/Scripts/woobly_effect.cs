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
    private float _explotionTime = 0f;
    private float _explotionEffekt;
    private bool _curentlyExploding;
    private bool _hasFormed = false;
    public int i;
    private bool _isExploding = false;
    void Update()
    {
        GetExplosiveData();
       {
           _explotionEffekt = _distanceFromExplotion * ExplotionCurve.Evaluate(Time.time);
           _timer += 1 * Time.deltaTime;
       }
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

        if (_distanceFromExplotion > 0f && _curentlyExploding)
        {
            _explotionTime = 2f;
            _curentlyExploding = false;
        }

        if (_distanceFromExplotion == 0f) _curentlyExploding = true;
    }
    private void FixedUpdate()
    {
        if (_distanceFromExplotion > 0f) _explotionTime -= 0.02f;
    }
    private void AnimateTheCurves(AnimationCurve curve)
    {
        transform.localScale = Vector3.one * (curve.Evaluate(_timer) + _explotionEffekt);
    }

    public float distance;
    
    private void GetExplosiveData()
    {
        foreach (var t in ExplosiveChargeController._charges)
        {
            if (t.GetComponent<ExplosiveCharge>()._hasExploded)
            {
                distance = Vector3.Distance(transform.parent.position, t.transform.position);
                if (distance > minDistanceFromExplotion)
                {
                    _isExploding = true;
                }
                //print("This is the distance between" + t.gameObject.name + " and " + transform.parent.name + " : " + distance);
            }
        }
    }
}