using System;
using Unity.VisualScripting;
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
    private IFunctional[] functions;

    public String XfuncName;
    public String YfuncName;
    public String ZfuncName;

    private float t = 0;
    public float dt;
    [SerializeField, Range(-1f, 1f)] float r;

    void Start()
    {
        functions = new IFunctional[3];
        functions[0] = new SinFunc();
        functions[1] = new CosFunc();
        functions[2] = new ZeroFunc();
    }

    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        var z = transform.position.z;
        var pos = new Vector3(x + (r * GetFunc(XfuncName).Invoke(t)), y + (r * GetFunc(YfuncName).Invoke(t)), z + (r * GetFunc(ZfuncName).Invoke(t)));
        gameObject.transform.position = pos;
        t += dt;
    }

    IFunctional GetFunc(String name)
    {
        if (name == "sin")
        {
            return functions[0];
        }
        else if (name == "cos")
        {
            return functions[1];
        }
        else
        {
            return functions[2];
        }
    }
}
