using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float duration = 10f;
    public float wait = 2f;
    public Transform start;
    public Transform end;

    bool patrol = false;

    void Update()
    {
        if (!patrol)
            StartCoroutine(StartPatrol());
    }

    IEnumerator StartPatrol() 
    {
        patrol = true;

        float time;

        transform.position = start.position;

        time = 0f;
        while(Vector2.Distance(transform.position, end.position) > 0.01f)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(start.position, end.position, time / duration);
            yield return null;
        }

        transform.position = end.position;

        yield return new WaitForSeconds(wait);
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        time = 0f;
        while(Vector2.Distance(transform.position, start.position) > 0.01f)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(end.position, start.position, time / duration);
            yield return null;
        }

        yield return new WaitForSeconds(wait);
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        patrol = false;
    }
}
