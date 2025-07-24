using System;
using System.Collections.Generic;
using UnityEngine;

public class ApproachingLaserManager : LaserAdventureGame
{
    [SerializeField]
    public GameObject origin;
    private ApproachingLaser origianlLaser;

    [SerializeField] public float freq_s;
    [SerializeField] public float speed;
    private float nextInstantiateTime = 0;
    private float currentTime = 0;
    List<Tuple<Vector3, Quaternion>> randomLaserOps;
    System.Random rand = new();

    void Start()
    {
        randomLaserOps = new();
        origianlLaser = origin.GetComponent<ApproachingLaser>();
        randomLaserOps.Add(new(new Vector3(0, 0.9f, 0), Quaternion.Euler(0, 0, -100)));
        randomLaserOps.Add(new(new Vector3(0, 0.9f, 0), Quaternion.Euler(0, 0, -86)));
        randomLaserOps.Add(new(new Vector3(2.0f, 4.0f, 0), Quaternion.Euler(0, 0, 150)));
        randomLaserOps.Add(new(new Vector3(2.0f, 4.0f, 0), Quaternion.Euler(0, 0, -150)));
        randomLaserOps.Add(new(new Vector3(0, 0.9f, 0), Quaternion.Euler(0, 0, -70)));
    }

    bool ShouldInstantieateNewLaser()
    {
        currentTime += Time.deltaTime;
        if (currentTime > nextInstantiateTime)
        {
            nextInstantiateTime = currentTime + freq_s;
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        if (GetGameState() == GameState.PlayingApproachingPostureLaser && ShouldInstantieateNewLaser())
        {
            var obj = Instantiate(origianlLaser);
            var randomIndex = rand.Next(0, randomLaserOps.Count);
            Debug.Log(randomIndex);
            (Vector3 pos, Quaternion rot) = randomLaserOps[randomIndex];
            obj.GetComponent<ApproachingLaser>().Initialize(rot, pos, 0.05f);
        }
    }
}
