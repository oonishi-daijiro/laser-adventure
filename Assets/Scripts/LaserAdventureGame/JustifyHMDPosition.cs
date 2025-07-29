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

    void Update()
    {
        JustifyPlaceByKeydown();
        StartCoroutine(Justify());
    }

    IEnumerator Justify()
    {
        yield return new WaitForEndOfFrame();
        if (!isJustifiedOnce)
        {
            var camYangleRotation = HMDCam.transform.localEulerAngles.y;
            var localCamPos = HMDCam.transform.localPosition;
            Debug.Log($"{localCamPos}");
            var newX = gameObject.transform.position.x - localCamPos.x;
            var newY = gameObject.transform.position.y - (localCamPos.y - 1.3f);
            var newZ = gameObject.transform.position.z - localCamPos.z;

            gameObject.transform.position = new Vector3(newX, newY, newZ);
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
    }
}
