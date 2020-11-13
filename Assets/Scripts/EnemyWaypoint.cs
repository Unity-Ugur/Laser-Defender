using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoint : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    List<Transform> enemyWaypoints;

    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyWaypoints = waveConfig.GetWaypoints(); 
        transform.position = enemyWaypoints[waypointIndex].transform.position;
        waypointIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointIndex <= enemyWaypoints.Count - 1)
        {
            var targetPosition = enemyWaypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            // Debug.Log(transform.position);
            // Debug.Log(targetPosition);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}