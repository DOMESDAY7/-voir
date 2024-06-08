using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public Vector3 firstTargetPosition;
    public Vector3 secondTargetPosition;
    public float moveDuration;
    public float waitDuration;

    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(MoveAndWaitCoroutine());
    }

    public IEnumerator MoveAndWaitCoroutine()
    {
        yield return StartCoroutine(MoveOverTime(firstTargetPosition, moveDuration));

        if (animator != null)
        {
            animator.Play("Idle_A");
            animator.speed = 0.6f;
        }

        yield return new WaitForSeconds(waitDuration);

        yield return StartCoroutine(MoveOverTime(secondTargetPosition, moveDuration));

        Destroy(gameObject);
    }

    private IEnumerator MoveOverTime(Vector3 targetPosition, float duration)
    {
        if (animator != null)
        {
            animator.Play("Walk");
            animator.speed = 0.6f;
        }


        Vector3 startPosition = transform.position;
        transform.LookAt(targetPosition);
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}
