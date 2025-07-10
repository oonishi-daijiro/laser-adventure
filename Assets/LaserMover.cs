using System;
using System.Collections.Generic;
using UnityEngine;

interface IFunctional
{
    float Invoke(float t);
};

class SinFunc : IFunctional
{
    public float Invoke(float t)
    {
        return Mathf.Sin(t);
    }
};



class CosFunc : IFunctional
{
    public float Invoke(float t)
    {
        return Mathf.Cos(t);
    }
}

class ZeroFunc : IFunctional
{
    public float Invoke(float _)
    {
        return 0;
    }
}

public class LaserMover : MonoBehaviour
{
    private Dictionary<String, IFunctional> funcMap;

    public String XfuncName;
    public String YfuncName;
    public String ZfuncName;

    private float t = 0;
    public float dt;
    [SerializeField] float theta;
    [SerializeField, Range(-1f, 1f)] float r;

    void Start()
    {
        funcMap = new Dictionary<string, IFunctional>
        {
            { "sin", new SinFunc() },
            { "cos", new CosFunc() },
            { "zero", new ZeroFunc() },
            { "", new ZeroFunc() }

        };
    }

    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        var z = transform.position.z;
        var pos = new Vector3(x + (r * funcMap[XfuncName].Invoke(t + theta)), y + (r * funcMap[YfuncName].Invoke(t + theta)), z + (r * funcMap[ZfuncName].Invoke(t + theta)));
        gameObject.transform.position = pos;
        t += dt;
    }

}
