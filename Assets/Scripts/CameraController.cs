using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movingSpeed = 0.3f;
    public float zoomingSpeed = 0.1f;

    private void Update()
    {
        if (GameManager.IsEnd)
        {
            transform.position = new Vector3(2.4f, 2.6f, 2.5f);
            GetComponent<Camera>().orthographicSize = 1.9f;
        }
        else
        {
            float dis = MCubeManager.LastPosition.y - 0.45f - (transform.position.y - 2.6f);
            float size = 1f - MCubeManager.LastWidth - (1.9f - GetComponent<Camera>().orthographicSize);
            if (dis > 0.1f)
            {
                Vector3 pos = transform.position;
                pos.y += movingSpeed * Time.deltaTime;
                transform.position = pos;
            }
            if (size > 0.2f)
            {
                float osize = GetComponent<Camera>().orthographicSize;
                osize -= zoomingSpeed * Time.deltaTime;
                GetComponent<Camera>().orthographicSize = osize;
            }
        }
    }

}
