using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRoomData : MonoBehaviour
{
	public Text displayTxt;

	private void Start()
	{
		displayTxt.text = PhotonCommunicator.GetCurrentRoomName();
	}
} 
