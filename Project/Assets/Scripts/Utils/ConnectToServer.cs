using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectToServer : MonoBehaviour // This class provides a .photonView and all callbacks/events that PUN can call
{
	[Range(1,15)]
	public float deadTime = 3;
    void Start()
    {
		PhotonCommunicator.ConnectUsingSettings();
		PhotonCommunicator.receivedOnConnectedToMaster += OnConnectedToMaster;
		StartCoroutine(WaitingForConnection());
    }

	public void OnConnectedToMaster() //Called when the client is connected to the Master Server and ready for matchmaking and other tasks. 
	{
		SceneLoader.LoadScene(SceneData.MainScene);
		PhotonCommunicator.receivedOnConnectedToMaster -= OnConnectedToMaster;
	}

	private IEnumerator WaitingForConnection()
	{
		yield return new WaitForSeconds(deadTime);
		if(SceneLoader.GetSceneName() == SceneData.ConnectToServerLoading)
		{
			Debug.LogError($"Unable to connect within {deadTime} seconds, need a fallback here");
		}
	}
}
