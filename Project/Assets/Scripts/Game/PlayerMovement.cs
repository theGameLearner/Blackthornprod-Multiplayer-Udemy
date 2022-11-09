using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
	public float speed;
    PhotonView pView;
	Vector2 moveAmt;
	Vector2 moveInp;

	private void Awake()
	{
		pView = GetComponent<PhotonView>();
		moveInp = new Vector2();
	}
	void Update()
    {
        if(pView.IsMine)
		{
			moveInp.x = Input.GetAxisRaw("Horizontal");
			moveInp.y = Input.GetAxisRaw("Vertical");
			moveInp.Normalize();
			moveAmt = moveInp * speed * Time.deltaTime;
			transform.position += (Vector3)moveAmt;
		}
    }
}
