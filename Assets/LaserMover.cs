using System;
using System.Collections.Generic;
using UnityEngine;

public class LaserMover : MonoBehaviour
{
    delegate float fun(float v);

    private Dictionary<string, fun> funcMap;

    public String XfuncName;
    public String YfuncName;
    public String ZfuncName;

    private float t = 0;
    public float dt;
    [SerializeField] float theta;
    [SerializeField, Range(-1f, 1f)] float r;

    void Start()
    {
        funcMap = new Dictionary<string, fun>
        {
            { "sin", MathF.Sin },
            { "cos", Mathf.Cos },
            { "zero", v => {return 0.0f; } },
            { "", v=>{return 0.0f; } }

        };
    }

    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        var z = transform.position.z;
        var pos = new Vector3(x + (r * funcMap[XfuncName](t + theta)), y + (r * funcMap[YfuncName](t + theta)), z + (r * funcMap[ZfuncName](t + theta)));
        gameObject.transform.position = pos;
        t += dt;
    }

}
