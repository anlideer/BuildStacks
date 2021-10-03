using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCube : MonoBehaviour
{
    public float dropSpeed = 10f;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        Vector3 movVec = new Vector3(0, -1 * dropSpeed * Time.deltaTime, 0);
        transform.position += movVec;
    }
}
