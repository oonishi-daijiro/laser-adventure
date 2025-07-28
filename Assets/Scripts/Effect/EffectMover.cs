using UnityEngine;

public class EffectMover : MonoBehaviour
{
    [Header("移動先の座標")]
    public Vector3 targetPosition = new Vector3(0, 5, 0);

    [Header("移動にかける時間（秒）")]
    public float moveDuration = 2f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(DelayedMove());
    }

    System.Collections.IEnumerator DelayedMove()
    {
        // シーン読み込み後1秒待機
        yield return new WaitForSeconds(1f);

        float moveTimer = 0f;
        while (moveTimer < moveDuration)
        {
            moveTimer += Time.deltaTime;
            float t = moveTimer / moveDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        // 最終位置にしっかり合わせる
        transform.position = targetPosition;
    }
}
