using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	private static Coroutine loadingCoroutine;
	private static SceneLoader instance;
	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		instance = this;
		SceneManager.sceneLoaded += OnSceneLoadedEvent;
	}
	public static void LoadScene(int index, float delay = 0)
	{
		if (loadingCoroutine != null)
		{
			instance.StopCoroutine(loadingCoroutine);
		}
		loadingCoroutine = instance.StartCoroutine(LoadingCoroutine(()=> SceneManager.LoadScene(index), delay));
	}

	private static IEnumerator LoadingCoroutine(Action callBack, float delay)
	{
		yield return new WaitForSeconds(delay);
		callBack();
	}

	public static void LoadScene(string sceneName, float delay = 0)
	{
		if(loadingCoroutine != null)
		{
			instance.StopCoroutine(loadingCoroutine);
		}
		loadingCoroutine = instance.StartCoroutine(LoadingCoroutine(() => SceneManager.LoadScene(sceneName), delay));
		
	}

	public static void LoadScene(SceneData sceneEnum, float delay = 0)
	{
		LoadScene((int)sceneEnum, delay);
	}

	public static SceneData GetSceneName()
	{
		return (SceneData)SceneManager.GetActiveScene().buildIndex;
	}

	private void OnSceneLoadedEvent(Scene arg0, LoadSceneMode arg1)
	{
		Debug.Log($"Loaded scene {arg0.name} with enum called {(SceneData)arg0.buildIndex} at {Time.realtimeSinceStartup} seconds");
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoadedEvent;
	}
}
