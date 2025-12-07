using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CinematicEnd : MonoBehaviour
{
    public string nextSceneName = "jspckoi";
    void Start()
    {
      VideoPlayer vp = GetComponent<VideoPlayer>();
      vp.loopPointReached += OnVideoFinished;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
    
    void LoadNextscene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
