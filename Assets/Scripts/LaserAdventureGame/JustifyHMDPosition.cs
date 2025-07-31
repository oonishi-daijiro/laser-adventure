using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class JustifyHMDPosition : LaserAdventureGame
{
    [SerializeField] GameObject HMDCam;
    private Vector3 forwardBackwardDelta = new(0, 0, 0.1f);
    private Vector3 leftRightDelta = new(0.1f, 0, 0);
    private Vector3 upDownDelta = new(0, 0.1f, 0);
    private bool isJustifiedOnce = false;
    void Start()
    {
        StartCoroutine(Justify());
    }

    void Update()
    {
        JustifyPlaceByKeydown();
    }

    IEnumerator Justify()
    {
        OVRTracker tracker = new();
        yield return tracker;
        Debug.Log("tracked");

        if (!isJustifiedOnce)
        {
            var camYangleRotation = HMDCam.transform.localEulerAngles.y;
            var camPos = HMDCam.transform.position;
            Debug.Log(camPos);
            gameObject.transform.position += new Vector3(gameObject.transform.position.x - camPos.x, gameObject.transform.position.y - camPos.y, gameObject.transform.position.z - camPos.z);
            gameObject.transform.rotation = Quaternion.AngleAxis(-camYangleRotation, Vector3.up);
            isJustifiedOnce = true;
            SetGameState(GameState.Playing);
        }
    }


    void JustifyPlaceByKeydown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.position += forwardBackwardDelta;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.transform.position -= forwardBackwardDelta;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.position += leftRightDelta;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.position -= leftRightDelta;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.position += upDownDelta;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            gameObject.transform.position -= upDownDelta;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            var camYangleRotation = HMDCam.transform.localEulerAngles.y;
            var camPos = HMDCam.transform.position;
            gameObject.transform.position += new Vector3(0 - camPos.x, 1.2f - camPos.y, -8 - camPos.z);
            gameObject.transform.rotation = Quaternion.AngleAxis(-camYangleRotation, Vector3.up);
        }
    }
}
