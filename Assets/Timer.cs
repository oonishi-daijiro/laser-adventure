using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float currentSec = 0;
    private float previousSec = 0;

    private List<listenner> listenners;

    void Start()
    {
        listenners = new List<listenner>();
    }

    void Update()
    {
        currentSec += Time.deltaTime;

        if (currentSec - previousSec >= 1.0f)
        {
            previousSec = currentSec;
            foreach (var listenner in listenners) listenner();
        }
    }


    public delegate void listenner();
    public void AddPerSecListenner(listenner l)
    {
        listenners.Add(l);
    }
}
