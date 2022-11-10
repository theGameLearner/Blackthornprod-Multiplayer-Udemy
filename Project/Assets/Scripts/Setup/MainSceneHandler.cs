using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneHandler : MonoBehaviour
{
	public InputField createRoomName;
	public InputField joinRoomName;
	public Button createRoomBtn;
	public Button joinRoomBtn;

	private void Start()
	{
		createRoomBtn.onClick.AddListener(CreateRoomAction);
		joinRoomBtn.onClick.AddListener(JoinRoomAction);
	}

	private void OnEnable()
	{
		PhotonCommunicator.receivedOnJoinedRoom += OnRoomJoined;
	}

	void CreateRoomAction()
	{
		PhotonCommunicator.CreateRoom(createRoomName.text, (byte)2);
	}

	void JoinRoomAction()
	{
		PhotonCommunicator.JoinRoom(joinRoomName.text);
	}

	void OnRoomJoined()
	{
		Debug.Log($"Joined a new room");
		SceneLoader.LoadScene(SceneData.Room, true);
	}
	private void OnDisable()
	{
		PhotonCommunicator.receivedOnJoinedRoom -= OnRoomJoined;
	}

	private void OnDestroy()
	{
		createRoomBtn.onClick.RemoveListener(CreateRoomAction);
		joinRoomBtn.onClick.RemoveListener(JoinRoomAction);
	}
}
