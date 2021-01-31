using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public float timeBeforeDestroy = 1.0f;
    AudioSource bombSound;
    private void Start()
    {
        Destroy(gameObject.transform.parent.gameObject, timeBeforeDestroy);
        bombSound = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestructibleObject"))
        {
            //Destroy bomb after Animation is finished playing.
            bombSound.PlayDelayed(0.6f);
            Destroy(other.gameObject, timeBeforeDestroy);
        }

    }
 }
