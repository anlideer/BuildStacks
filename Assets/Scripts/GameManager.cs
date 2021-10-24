using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public static bool _isEnd;
    public static bool IsEnd
    {
        get { return _isEnd; }
        set { _isEnd = value; OnScoreUpdated(); }
    }
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
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("MovingCube");
            foreach(GameObject cube in cubes)
            {
                Destroy(cube);
            }
            Debug.Log("Destroy all cubes");
            IsEnd = false;
            MCubeManager.Reset();
            Score = 0;
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
