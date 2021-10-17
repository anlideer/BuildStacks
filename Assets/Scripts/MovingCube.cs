using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector3 moveDirection = new Vector3(0, 0, 1);

    private bool isMoving = true;

    private void OnEnable()
    {
        // random color
        GetComponent<Renderer>().material.color = GetRandomColor();
    }

    private void Start()
    {
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
        
    }

    // stop & slice...
    public void Stop()
    {
        // split
        Vector3 diffVec = transform.position - MCubeManager.LastPosition;
        Debug.Log("diff" + diffVec);
        float maxInterval = MCubeManager.lastWidth / 2 + transform.localScale.x / 2;
        if (Mathf.Abs(diffVec.x) >= maxInterval || Mathf.Abs(diffVec.z) >= maxInterval)
            return; // TODO: FAIL
        isMoving = false;
        // special case: current cube is "in" the last cube
        float minInterval = MCubeManager.lastWidth / 2 - transform.localScale.x / 2;
        if (Mathf.Abs(diffVec.x) <= minInterval && Mathf.Abs(diffVec.z) <= minInterval)
        {
            MCubeManager.LastPosition = transform.position;
            MCubeManager.lastWidth = transform.localScale.z;
        }
        else
        {
            if (diffVec.x != 0)
                SliceInX();
            else
                SliceInZ();
        }
        MCubeManager.SpawnCube(transform.localScale);
    }

    private void SliceInX()
    {
        Vector3 diffVec = transform.position - MCubeManager.LastPosition;
        Vector3 originalPos = transform.position;
        // the one remaining
        Vector3 scale = transform.localScale;
        scale.x = scale.x/2 - Mathf.Abs(diffVec.x) + MCubeManager.lastWidth / 2;
        transform.localScale = scale;
        Vector3 pos = transform.position;
        if (diffVec.x > 0)
            pos.x = MCubeManager.LastPosition.x + (Mathf.Abs(diffVec.x) / 2 - transform.localScale.z / 4 + MCubeManager.lastWidth / 4);
        else
            pos.x = MCubeManager.LastPosition.x - (Mathf.Abs(diffVec.x) / 2 - transform.localScale.z / 4 + MCubeManager.lastWidth / 4);
        Debug.Log("position " + pos);
        transform.position = pos;
        // the one dropping
        GameObject cube = Instantiate(Resources.Load("FakeCube") as GameObject);
        cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        Vector3 scale2 = transform.localScale;
        scale2.x = transform.localScale.z / 2 + Mathf.Abs(diffVec.x) - MCubeManager.lastWidth / 2;
        cube.transform.localScale = scale2;
        Vector3 pos2 = MCubeManager.LastPosition;
        if (diffVec.x > 0)
            pos2.x += Mathf.Abs(diffVec.x) / 2 + transform.localScale.z / 4 + MCubeManager.lastWidth / 4;
        else
            pos2.x -= Mathf.Abs(diffVec.x) / 2 + transform.localScale.z / 4 + MCubeManager.lastWidth / 4;
        Debug.Log("position2 " + pos2);
        cube.transform.position = pos2;

        MCubeManager.LastPosition = transform.position;
        MCubeManager.lastWidth = transform.localScale.z;
    }

    private void SliceInZ()
    {
        Vector3 diffVec = transform.position - MCubeManager.LastPosition;
        Vector3 originalPos = transform.position;
        // the one remaining
        Vector3 scale = transform.localScale;
        scale.z = scale.z / 2 - Mathf.Abs(diffVec.z) + MCubeManager.lastWidth / 2;
        transform.localScale = scale;
        Vector3 pos = transform.position;
        if (diffVec.z > 0)
            pos.z = MCubeManager.LastPosition.z + (Mathf.Abs(diffVec.z) / 2 - transform.localScale.x / 4 + MCubeManager.lastWidth / 4);
        else
            pos.z = MCubeManager.LastPosition.z - (Mathf.Abs(diffVec.z) / 2 - transform.localScale.x / 4 + MCubeManager.lastWidth / 4);
        Debug.Log("position " + pos);
        transform.position = pos;
        // the one dropping
        GameObject cube = Instantiate(Resources.Load("FakeCube") as GameObject);
        cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        Vector3 scale2 = transform.localScale;
        scale2.z = transform.localScale.x / 2 + Mathf.Abs(diffVec.z) - MCubeManager.lastWidth / 2;
        cube.transform.localScale = scale2;
        Vector3 pos2 = MCubeManager.LastPosition;
        if (diffVec.z > 0)
            pos2.z += Mathf.Abs(diffVec.z) / 2 + transform.localScale.x / 4 + MCubeManager.lastWidth / 4;
        else
            pos2.z -= Mathf.Abs(diffVec.z) / 2 + transform.localScale.x / 4 + MCubeManager.lastWidth / 4;
        Debug.Log("position2 " + pos2);
        cube.transform.position = pos2;

        MCubeManager.LastPosition = transform.position;
        MCubeManager.lastWidth = transform.localScale.x;
    }

    private Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

}
