using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomList : MonoBehaviour
{
	private RoomTemplate rooment;

	void Update()
	{

		rooment = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
		rooment.currentRooms.Add(this.gameObject);
	}
}
