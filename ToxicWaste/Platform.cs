using System;
using System.Collections;
using UnityEngine;

public class MoveObjectLoop : MonoBehaviour
{
    [Header("References")]
    public Transform targetObject;   // The object to move
    public Transform startTransform; // The Transform for the starting position
    public Transform endTransform;   // The Transform for the ending position

    [Header("Settings")]
    public float moveDuration = 1.5f; // Time to move from start to end

    private Vector3 startPosition;   // Fixed start position
    private Vector3 endPosition;     // Fixed end position
    private bool movingToEnd = true; // Tracks movement direction

    private void Start()
    {
        // Store the fixed positions at the start
        startPosition = startTransform.position;
        endPosition = endTransform.position;

        // Start the loop
        StartCoroutine(MoveLoop());
    }

    private IEnumerator MoveLoop()
    {
        while (true) // Infinite loop
        {
           
            float elapsedTime = 0f;
            Vector3 start = movingToEnd ? startPosition : endPosition;
            Vector3 end = movingToEnd ? endPosition : startPosition;

            while (elapsedTime < moveDuration)
            {
                float alpha = elapsedTime / moveDuration;
                targetObject.position = Vector3.Lerp(start, end, alpha);
                elapsedTime += Time.deltaTime;
                yield return null; // Wait for next frame
            }

            targetObject.position = end; // Ensure exact position
            movingToEnd = !movingToEnd; // Reverse direction
            yield return new WaitForSeconds(0.5f); // Small delay before reversing
        }
    }

    internal void StartMoveLoop()
    {
        throw new NotImplementedException();
    }
}