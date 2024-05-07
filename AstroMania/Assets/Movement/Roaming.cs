using System.Collections;
using UnityEngine;

public class Roaming : MonoBehaviour
{
    [SerializeField] private Movement movement;
    
    [SerializeField] private float minRoamDistance = 2;
    [SerializeField] private float maxRoamDistance = 10;
    private readonly float destinationThreshold = 1f;

    private Vector2 startPosition;
    private Vector2 destination;

    private float minWaitTime = 0.5f;
    private float maxWaitTime = 1f;
    private bool isWaiting = false;

    private void Start()
    {
        startPosition = transform.position;
        destination = GetRoamDestination();
    }
    public void Roam()
    {
        if (isWaiting) return;

        movement.MoveTowards(destination);
        if (Vector2.Distance(transform.position, destination) <= destinationThreshold)
        {
            StartCoroutine(Wait());
            destination = GetRoamDestination();
        }
    }

    private Vector2 GetRoamDestination()
    {
        var randomXDir = Random.Range(-1, 1);
        var randomYDir = Random.Range(-1, 1);
        var randomDirection = new Vector2(randomXDir, randomYDir);

        var randomDistance = Random.Range(minRoamDistance, maxRoamDistance);
        return startPosition + randomDirection * randomDistance;
    }

    private IEnumerator Wait()
    {
        isWaiting = true;
        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
    }
}