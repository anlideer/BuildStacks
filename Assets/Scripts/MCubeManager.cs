using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCubeManager : MonoBehaviour
{
    public MovingCube temp;
    public static MovingCube CurrentCube { get; private set; }
    public static Vector3 LastPosition { get; set; }

    private void Start()
    {
        LastPosition = new Vector3(0, 0.55f, 0);
        // tmp
        CurrentCube = temp;
    }
}
