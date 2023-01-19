using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public int score;

    public void DestroyObject()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        AudioManager.PlayOneShot(SFX.Explosion);
        ScoreManager.AddScore(score);
        gameObject.SetActive(false);
    }
}
