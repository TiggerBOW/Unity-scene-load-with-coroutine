using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHandler : MonoBehaviour
{
    public static LoadSceneHandler Instance;
    private bool _isLoading = false;
    private void Awake()
    {
        if (Instance == null) // Singleton implementation
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isLoading) // Client
        {
            StartCoroutine(LoadSceneCoroutine(1,LoadSceneMode.Single));
        }
    }
    private IEnumerator LoadSceneCoroutine(int sceneIndex,LoadSceneMode mode)
    {
        _isLoading = true;
        AsyncOperation sync = SceneManager.LoadSceneAsync(sceneIndex,mode);
        yield return sync;
        //After scene loaded...
        _isLoading = false;
        Debug.Log(SceneManager.GetActiveScene().name + " loaded");
    }
}
