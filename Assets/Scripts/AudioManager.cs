using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager Instance;
    static AudioSource source;

    public AudioClip[] explosions; 
    public AudioClip shoot;

    void Start()
    {
        if (!Instance)
            Instance = this;
        else 
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        source = GetComponent<AudioSource>();
    }

    public static void PlayOneShot(SFX sfx)
    {
        switch (sfx)
        {
            case SFX.Explosion:
                int index = Random.Range(0, Instance.explosions.Length - 1);
                source.PlayOneShot(Instance.explosions[index]);
                Debug.Log(Instance.explosions.Length);
                Debug.Log(index);
                break;

            case SFX.Shoot:
                source.PlayOneShot(Instance.shoot);
                break;

            default:
                break;
        }
    }
}

public enum SFX 
{
    Explosion,
    Shoot
}