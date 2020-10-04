using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
	Rigidbody2D rb;

	[SerializeField]
	Transform[] waypoints;

	[SerializeField]
	float moveSpeed = 2f;

	int waypointIndex = 0;

    private void Awake()
    {
		rb = GetComponent<Rigidbody2D>();
    }

    void Start()
	{
		transform.position = waypoints[waypointIndex].transform.position;
	}

	void FixedUpdate()
	{
		Move();
	}

	void Move()
	{

		rb.velocity = new Vector2(waypoints[waypointIndex].transform.position.x - transform.position.x, waypoints[waypointIndex].transform.position.y - transform.position.y).normalized * moveSpeed;

		if((waypoints[waypointIndex].transform.position - transform.position).magnitude <= 0.1f)
        {
			waypointIndex += 1;
		}

		if (waypointIndex == waypoints.Length)
			waypointIndex = 0;
	}

}