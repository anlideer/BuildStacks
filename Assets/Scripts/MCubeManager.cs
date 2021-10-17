using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCubeManager : MonoBehaviour
{
    public static MovingCube CurrentCube { get; private set; }
    public static Vector3 LastPosition { get; set; }
    public static float lastWidth;
    public static bool isZ = true;

    private void Start()
    {
        LastPosition = new Vector3(0, 0.45f, 0);
        lastWidth = 1f;
        SpawnCube(new Vector3(1f, 0.1f, 1f));
    }

    public static void SpawnCube(Vector3 scale)
    {
        GameObject obj = Instantiate(Resources.Load("MovingCube") as GameObject);
        MovingCube mc = obj.GetComponent<MovingCube>();
        Debug.Log("Lastposition" + LastPosition);
        if (isZ)
        {
            scale.z = scale.x;
            obj.transform.localScale = scale;
            obj.transform.position = LastPosition + new Vector3(0, 0.1f, -2f);
            Debug.Log("spawn " +obj.transform.position);
            mc.moveDirection = new Vector3(0, 0, 1f);
        }
        else
        {
            scale.x = scale.z;
            obj.transform.localScale = scale;
            obj.transform.position = LastPosition + new Vector3(-2f, 0.1f, 0);
            Debug.Log("spawn " + obj.transform.position);
            mc.moveDirection = new Vector3(1f, 0, 0);
        }

        CurrentCube = mc;
        isZ = !isZ;
    }
}
