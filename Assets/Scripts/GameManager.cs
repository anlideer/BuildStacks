using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int _score;
    public static int Score
    {
        get { return _score; }
        set {
            _score = value;
            OnScoreUpdated();
        }
    }
    public static bool IsEnd { get; set; }
    public static event Action OnScoreUpdated = delegate { };

    private void Start()
    {
        Score = 0;
        IsEnd = true;
    }

    private void Update()
    {
        if (!IsEnd)
        {
            DetectInput();
        }
        else
        {
            DetectStart();
        }

    }

    private void DetectStart()
    {
        if (Input.anyKeyDown)
        {
            IsEnd = false;
        }
    }

    private void DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(MCubeManager.CurrentCube);
            MCubeManager.CurrentCube.Stop();
        }
    }

}
