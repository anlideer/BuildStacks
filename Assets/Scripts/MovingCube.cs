using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public float moveSpeed = 1f;

    private bool isMoving = true;

    private void Start()
    {
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        
    }

    // stop & slice...
    public void Stop()
    {
        Debug.Log("Stop");
        isMoving = false;

        // split
        Vector3 diffVec = transform.position - MCubeManager.LastPosition;
        Vector3 originalPos = transform.position;
        // the one remaining
        Vector3 scale = transform.localScale;
        scale.x = 1 - Mathf.Abs(diffVec.x);
        scale.z = 1 - Mathf.Abs(diffVec.z);
        transform.localScale = scale;
        Vector3 pos = transform.position;
        pos.x /= 2;
        pos.z /= 2;
        transform.position = pos;
        // the one dropping
        GameObject cube = Instantiate(Resources.Load("FakeCube") as GameObject);
        Vector3 scale2 = cube.transform.localScale;
        if (diffVec.x != 0)
            scale2.x *= Mathf.Abs(diffVec.x);
        else if (diffVec.z != 0)
            scale2.z *= Mathf.Abs(diffVec.z);
        cube.transform.localScale = scale2;
        Vector3 pos2 = 0.5f * (diffVec.normalized + diffVec);
        pos2.y = originalPos.y;
        cube.transform.position = pos2;

        // TODO: store position
    }


}
