using System;
using System.Collections.Generic;
using UnityEngine;

public class ApproachingLaserManager : InvokePeriodically
{

    [SerializeField]
    public GameObject origin;
    private ApproachingFromFront origianlLaser;

    List<Tuple<Vector3, Quaternion>> randomLaserOps;
    System.Random rand = new();

    void Start()
    {
        base.Start();
        randomLaserOps = new();
        origianlLaser = origin.GetComponent<ApproachingFromFront>();
        randomLaserOps.Add(new(new Vector3(0, 0.9f, 0), Quaternion.Euler(0, 0, -100)));
        randomLaserOps.Add(new(new Vector3(0, 0.9f, 0), Quaternion.Euler(0, 0, -86)));
        randomLaserOps.Add(new(new Vector3(2.0f, 4.0f, 0), Quaternion.Euler(0, 0, 150)));
        randomLaserOps.Add(new(new Vector3(-2.0f, 4.0f, 0), Quaternion.Euler(0, 0, -150)));
        randomLaserOps.Add(new(new Vector3(0, 0.9f, 0), Quaternion.Euler(0, 0, -70)));
    }

    protected override void Invoke()
    {
        if (GetGameState() == GameState.PlayingApproachingPostureLaser)
        {
            var obj = Instantiate(origianlLaser);
            var randomIndex = rand.Next(0, randomLaserOps.Count);
            (Vector3 pos, Quaternion rot) = randomLaserOps[randomIndex];
            Debug.Log($"random:{randomIndex}");
            obj.GetComponent<ApproachingFromFront>().Initialize(rot, pos, 0.05f);
        }
    }
}
