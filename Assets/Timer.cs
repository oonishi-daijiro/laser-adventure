using System;
using System.Collections.Generic;
using Oculus.Platform;
using UnityEngine;

public delegate void callback();
struct TimeoutCallback
{

    private readonly float timeoutSec;
    private readonly float registeredTime;
    private readonly callback callbackFunc;
    private bool isOutdated;

    public TimeoutCallback(callback clbk, float sec, float currentSec)
    {
        callbackFunc = clbk;
        timeoutSec = sec;
        registeredTime = currentSec;
        isOutdated = false;
    }

    public bool IsAlreadyCalled()
    {
        return isOutdated;
    }

    public void UpdateTime(float currentSec)
    {
        if (registeredTime + timeoutSec > currentSec)
        {
            callbackFunc();
            isOutdated = true;
        }
    }
};

public class Timer : MonoBehaviour
{
    private float currentSec = 0;
    private float previousSec = 0;

    private List<listenner> listenners;
    private List<TimeoutCallback> timeoutCallbacks;

    void Awake()
    {
        Debug.Log("construct timer");
        listenners = new List<listenner>();
        timeoutCallbacks = new List<TimeoutCallback>();
    }

    void Update()
    {
        currentSec += Time.deltaTime;
        foreach (var callback in timeoutCallbacks)
        {
            callback.UpdateTime(currentSec);
            if (callback.IsAlreadyCalled())
            {
                timeoutCallbacks.Remove(callback);
            }
        }


        if (currentSec - previousSec >= 1.0f)
        {
            previousSec = currentSec;
            foreach (var listenner in listenners) listenner();
        }
    }
    public void SetTimeout(callback cb, float timeoutSec)
    {
        timeoutCallbacks.Add(new TimeoutCallback(cb, timeoutSec, currentSec));
    }

    public delegate void listenner();
    public void AddPerSecListenner(listenner l)
    {
        listenners.Add(l);
    }
}
