using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayYeet : MonoBehaviour
{
    public AudioSource Yeet;
    private Vector3 originalPosition;
    private bool _playOnce = false;
    // Start is called before the first frame update
    void Start()
    {
       //Yeet = gameObject.GetComponent<AudioSource>();
        originalPosition = gameObject.transform.position;
        Yeet.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (originalPosition.x + 1.0f < gameObject.transform.position.x )
        {
            if(!_playOnce)
            {
                _playOnce = true;
                Yeet.Play();
            }
           
            //Debug.Log(originalPosition.x);

        }
    }
}
