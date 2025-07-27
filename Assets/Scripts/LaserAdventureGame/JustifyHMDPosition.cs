using System.Collections;
using UnityEngine;

public class JustifyHMDPosition : LaserAdventureGame
{
    [SerializeField] GameObject HMDCam;
    private Vector3 forwardBackwardDelta = new(0, 0, 0.1f);
    private Vector3 leftRightDelta = new(0.1f, 0, 0);
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
            // var camPos = HMDCam.transform.position;
            // Debug.Log($"campos {camPos}");
            // var offset = camPos - gameObject.transform.position;
            // gameObject.transform.position = new Vector3(0, 1.4f, -9) - offset;
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
            SetGameState(GameState.Playing);
        }
    }
}
