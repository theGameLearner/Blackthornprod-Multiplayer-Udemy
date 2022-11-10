using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonCommunicator : MonoBehaviourPunCallbacks
{
	public static PhotonCommunicator Instance { get; private set; }

	#region PhotonActions
	/// <summary>
	/// Whenever Server connection is established, this action is called
	/// </summary>
	public static Action receivedOnConnectedToMaster;
	/// <summary>
	/// Whenever the player Joins a room or creates a room, server calls this action
	/// </summary>
	public static Action receivedOnJoinedRoom;

	#endregion //PhotonActions

	#region SetUp
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(this);
		}
	}
	#endregion

	#region CallsForPhoton
	public static void ConnectUsingSettings()
	{
		PhotonNetwork.ConnectUsingSettings();
		// calls all OnConnectedToMaster() methods of all MonoBehaviourPunCallbacks derived scripts when the connection is established
	}

	public static void CreateRoom(string roomName, byte maxPlayers)
	{
		RoomOptions roomOptions = new RoomOptions();
		roomOptions.MaxPlayers = maxPlayers;
		PhotonNetwork.CreateRoom(roomName, roomOptions);
		// calls all OnJoinedRoom() method of all MonoBehaviourPunCallbacks derived scripts when the player joins the room 
	}

	public static void JoinRoom(string roomName)
	{
		PhotonNetwork.JoinRoom(roomName);
		// calls all OnJoinedRoom() method of all MonoBehaviourPunCallbacks derived scripts when the player joins the room 
	}

	public static string GetCurrentRoomName()
	{
		string currRoomName = PhotonNetwork.CurrentRoom.Name;
		if (string.IsNullOrEmpty(currRoomName))
		{
			Debug.LogError("Could not get current room name");
		}

		return currRoomName;
	}

	public static GameObject Instantiate(string pName, Vector2 pos, Quaternion rot)
	{
		Debug.LogError($"Instantiating a new Object");
		return PhotonNetwork.Instantiate(pName, pos, rot);
	}

	public static void LoadLevel(int buildIndex)
	{
		PhotonNetwork.AutomaticallySyncScene = true;
		PhotonNetwork.LoadLevel(buildIndex);
	}

	#endregion CallsForPhoton

	#region CallbackFromPhoton
	public override void OnConnectedToMaster() //Called when the client is connected to the Master Server and ready for matchmaking and other tasks. 
	{
		base.OnConnectedToMaster();
		if(receivedOnConnectedToMaster != null)
		{
			receivedOnConnectedToMaster();
		}
	}

	public override void OnJoinedRoom()
	{
		base.OnJoinedRoom();
		if (receivedOnJoinedRoom != null)
		{
			receivedOnJoinedRoom();
		}
	}
	#endregion

}
