using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    [Range(0, 3.0f)]
    public float connectTime = 1;
    void Start()
    {
        Invoke(nameof(ConnectToServer), connectTime); // ConnectToServerLoading
    }

    void ConnectToServer()
	{
        SceneLoader.LoadScene(SceneData.ConnectToServerLoading);
    }
}
