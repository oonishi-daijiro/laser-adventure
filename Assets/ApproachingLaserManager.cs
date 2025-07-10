using UnityEngine;

public class ApproachingLaserManager : MonoBehaviour
{
    [SerializeField]
    public GameObject origin;
    private ApproachingLaser origianlLaser;

    [SerializeField] public float freq_s;
    [SerializeField] public float speed;
    private float nextInstantiateTime = 0;
    private float currentTime = 0;

    [SerializeField, Range(0f, 1.0f)] float XRange;
    [SerializeField, Range(0f, 1.0f)] float YRange;
    [SerializeField, Range(0f, 1.0f)] float ZRange;

    [SerializeField, Range(0f, 360f)] float XRotationRange;
    [SerializeField, Range(0f, 360f)] float YRotationRange;
    [SerializeField, Range(0f, 360f)] float ZRotationRange;

    void Start()
    {
        origianlLaser = origin.GetComponent<ApproachingLaser>();
    }

    Quaternion RandomEulerRotation()
    {
        var x = Random.Range(0f, XRotationRange);
        var y = Random.Range(0f, YRotationRange);
        var z = Random.Range(0f, ZRotationRange);
        return Quaternion.Euler(new Vector3(x, y, z));
    }

    Vector3 RandomPos()
    {
        var x = Random.Range(-XRange, XRange);
        var y = Random.Range(-YRange, YRange);
        var z = Random.Range(-ZRange, ZRange);
        return new Vector3(x, y, z);
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
        if (ShouldInstantieateNewLaser())
        {
            Instantiate(origianlLaser).GetComponent<ApproachingLaser>().Initialize(RandomEulerRotation(), RandomPos(),speed);
        }
    }
}
