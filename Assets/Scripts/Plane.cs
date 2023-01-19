using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    float speed = 5f;
    public float minSpeed = 5f;
    public float maxSpeed = 10f;
    public float maneuverSpeed = 5f;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;

    [SerializeField] Sprite plane;
    [SerializeField] Sprite planeLeft;
    [SerializeField] Sprite planeRight;
    [SerializeField] Vector2 colliderSize;
    [SerializeField] Vector2 colliderSizeTilted;

    [SerializeField] GameObject explosion;

    float input = 0;

    BoxCollider2D c = null;
    Rigidbody2D rb = null;
    SpriteRenderer sr = null;

    void Start()
    {
        c = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            AudioManager.PlayOneShot(SFX.Shoot);
        }
    }

    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        inputY += 1;
        inputY /= 2;

        speed = Mathf.Lerp(minSpeed, maxSpeed, inputY);

        rb.position += new Vector2(maneuverSpeed * Time.fixedDeltaTime * input, speed * Time.fixedDeltaTime);

        HandleAnimations();
    }

    void HandleAnimations()
    {
        if (input == 0)
            sr.sprite = plane;
        else if (input > 0)
            sr.sprite = planeRight;
        else if (input < 0)
            sr.sprite = planeLeft;

        if (input == 0)
            c.size = colliderSize;
        else
            c.size = colliderSizeTilted;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyObject();
    }

    void DestroyObject()
    {
        if (explosion)
            Instantiate(explosion, transform.position, Quaternion.identity);

        AudioManager.PlayOneShot(SFX.Explosion);

        Destroy(this.gameObject);
    }
}
