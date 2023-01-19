using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    [SerializeField] GameObject explosion;

    void FixedUpdate()
    {
        transform.position += new Vector3(0, speed * Time.fixedDeltaTime, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<Enemy>().DestroyObject();
        }

        DestroyObject();
    }

    void DestroyObject()
    {
        if(explosion)
            Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
