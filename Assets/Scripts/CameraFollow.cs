using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform plane = null;
    public float speed = 10f;
    public float maxY = 100f;

    Vector3 offset = new Vector3();

    void Start()
    {
        plane = FindObjectOfType<Plane>().transform;
        offset = transform.position - plane.position;
    }

    void FixedUpdate()
    {
        if (!plane)
            return;

        Vector3 pos = new Vector3(0, plane.position.y + offset.y, plane.position.z + offset.z);
        if (pos.y > maxY)
            pos.y = maxY;

        transform.position = Vector3.Lerp(transform.position, pos, speed * 10f * Time.fixedDeltaTime);
    }
}
