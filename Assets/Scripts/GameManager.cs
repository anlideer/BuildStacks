using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        DetectInput();
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
