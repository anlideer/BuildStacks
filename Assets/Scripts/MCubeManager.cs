using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCubeManager : MonoBehaviour
{
    public static MovingCube CurrentCube { get; private set; }
    public static Vector3 LastPosition { get; set; }
    public static float LastWidth { get; set; }
    public static bool IsZ { get; set; }

    public static void Reset()
    {
        LastPosition = new Vector3(0, 0.45f, 0);
        LastWidth = 1f;
        IsZ = true;
        SpawnCube(new Vector3(1f, 0.1f, 1f));
    }

    public static void SpawnCube(Vector3 scale)
    {
        GameObject obj = Instantiate(Resources.Load("MovingCube") as GameObject);
        MovingCube mc = obj.GetComponent<MovingCube>();
        Debug.Log("Lastposition" + LastPosition);
        if (IsZ)
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
        IsZ = !IsZ;
    }
}
