using System.Collections;
using UnityEngine;

public class MoveObjectOnTrigger : MonoBehaviour
{
    [Header("References")]
    public Transform targetObject;
    public Transform startTransform;
    public Transform endTransform;

    [Header("Settings")]
    public float moveDuration = 1.5f;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingToEnd = true;
    private bool canMove = false;
    private Coroutine moveCoroutine;

    private void Start()
    {
        startPosition = startTransform.position;
        endPosition = endTransform.position;
        targetObject.position = startPosition;

        Debug.Log("MoveObjectOnTrigger initialized. Start Pos: " + startPosition + " | End Pos: " + endPosition);
    }

    public void StartMoveLoop()
    {
        if (!canMove)
        {
            canMove = true;
            Debug.Log("Move loop started.");
            moveCoroutine = StartCoroutine(MoveLoop());
        }
        else
        {
            Debug.Log("Move loop already running.");
        }
    }

    private IEnumerator MoveLoop()
    {
        while (canMove)
        {
            float elapsedTime = 0f;
            Vector3 start = movingToEnd ? startPosition : endPosition;
            Vector3 end = movingToEnd ? endPosition : startPosition;

            Debug.Log("Moving from " + start + " to " + end);

            while (elapsedTime < moveDuration)
            {
                float alpha = Mathf.Clamp01(elapsedTime / moveDuration);
                targetObject.position = Vector3.Lerp(start, end, alpha);
                elapsedTime += Time.deltaTime;
                yield return null; // Wait for the next frame
            }

            targetObject.position = end;
            movingToEnd = !movingToEnd;
            Debug.Log("Movement completed. Waiting before reversing...");

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void StopMoving()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
        
        canMove = false;
        Debug.Log("Movement stopped.");
    }
}