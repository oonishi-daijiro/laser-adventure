using System;
using System.Collections.Generic;
using Meta.XR.MultiplayerBlocks.Fusion.Editor;
using UnityEngine;

public class ApproachingLaserManager : InvokePeriodically
{

    [SerializeField]
    public GameObject origin;
    private ApproachingFromFront origianlLaser;
    List<Tuple<Vector3, Quaternion>> randomLaserOps;
    readonly System.Random rand = new();
    bool isAlreadyInvokedSetStateFunc = false;
    bool isAlreadyPlayedSoundEffect = false;

    new void Start()
    {
        base.Start();
        randomLaserOps = new();
        origianlLaser = origin.GetComponent<ApproachingFromFront>();
        var instantiateZpos = 3;
        randomLaserOps.Add(new(new Vector3(0, 0.9f, instantiateZpos), Quaternion.Euler(0, 0, -100)));
        randomLaserOps.Add(new(new Vector3(0, 0.9f, instantiateZpos), Quaternion.Euler(0, 0, -86)));
        randomLaserOps.Add(new(new Vector3(0.5f, 2.0f, instantiateZpos), Quaternion.Euler(0, 0, 150)));
        randomLaserOps.Add(new(new Vector3(0, 4.0f, instantiateZpos), Quaternion.Euler(0, 0, -150)));
        randomLaserOps.Add(new(new Vector3(0, 0.9f, instantiateZpos), Quaternion.Euler(0, 0, -70)));
        randomLaserOps.Add(new(new Vector3(0, 0.9f, instantiateZpos), Quaternion.Euler(0, 0, 70)));
        randomLaserOps.Add(new(new Vector3(0, 0.9f, instantiateZpos), Quaternion.Euler(30, 0, 70)));
        randomLaserOps.Add(new(new Vector3(0, 1.2f, instantiateZpos), Quaternion.Euler(0, 30, -70)));
        randomLaserOps.Add(new(new Vector3(0, 1.2f, instantiateZpos), Quaternion.Euler(0, -30, -70)));
        randomLaserOps.Add(new(new Vector3(0, 0, instantiateZpos), Quaternion.Euler(0, 0, 90)));
    }

    void InstantiateNewRandomLaser()
    {
        var obj = Instantiate(origianlLaser);
        var randomIndex = rand.Next(0, randomLaserOps.Count);
        (Vector3 pos, Quaternion rot) = randomLaserOps[randomIndex];
        Debug.Log(pos);
        obj.GetComponent<ApproachingFromFront>().Initialize(rot, pos, 0.025f, "Laser");
    }

    protected override void Invoke()
    {
        if (GetGameState() == GameState.PlayingApproachingPostureLaser)
        {
            if (approachingPostureLaserRemains <= 5)
            {
                InstantiateNewRandomLaser();
            }
            InstantiateNewRandomLaser();
            DecreaseApproachingPostureLaserRemainCount();
            if (approachingPostureLaserRemains == 0 && GetGameState() == GameState.PlayingApproachingPostureLaser && !isAlreadyInvokedSetStateFunc)
            {
                isAlreadyInvokedSetStateFunc = true;
                Invoke(nameof(SetGameState2PostureLaser), 5);
            }
        }
    }
    void Update()
    {
        if (!isAlreadyPlayedSoundEffect && GetGameState() == GameState.PlayingApproachingPostureLaser)
        {
            SoundEffectManager.PlaySoundEffect(SoundEffectManager.SoundEffectKind.ApproachingLaserIgnition);
            isAlreadyPlayedSoundEffect = true;
        }
    }

    void SetGameState2PostureLaser()
    {
        SetGameState(GameState.PlayingPostureLaser);
        SoundEffectManager.PlaySoundEffect(SoundEffectManager.SoundEffectKind.Ignition);
    }

}
