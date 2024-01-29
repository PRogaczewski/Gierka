using UnityEngine;

public class SawMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject[] waypoints;

    private int currentWaypointIndex = 0;

    private float speed = 3f;

    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWaypointIndex++;

            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
