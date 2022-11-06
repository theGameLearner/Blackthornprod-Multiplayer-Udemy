using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
	public GameObject player;
	public float minX, minY, maxX, maxY;

	private void Start()
	{
		InstantiatePlayer();
	}

	private void InstantiatePlayer()
	{
		Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
		PhotonCommunicator.Instantiate(player.name, randomPosition, Quaternion.identity);
	}
}
