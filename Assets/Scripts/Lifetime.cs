using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifetime = 5f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);
    }
}
