using Oculus.Interaction;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class ApproachingFromFront : MonoBehaviour
{
    private float speed;

    void Update()
    {
        var newPos = gameObject.transform.position;
        newPos.z -= speed;
        gameObject.transform.position = newPos;
        if (gameObject.transform.position.z < -8.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Initialize(Quaternion rotation, Vector3 pos, float speed)
    {
        gameObject.transform.rotation *= rotation;
        gameObject.transform.position = pos;
        this.speed = speed;
        gameObject.tag = "Laser";
    }
}

public abstract class InvokePeriodically : LaserAdventureGame
{
    [SerializeField] private float freq;
    [SerializeField] private Timer timer;

    private int currentTime = 0;
    private int previousTime = 0;

    public void Start()
    {
        timer.AddPerSecListenner(PerSecListenner);
    }

    private void PerSecListenner()
    {
        currentTime += 1;
        if (currentTime - previousTime >= freq)
        {
            Invoke();
            previousTime = currentTime;
        }
    }

    protected abstract void Invoke();
};