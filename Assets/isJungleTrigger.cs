using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isJungleTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool collided = false;

    private void OnTriggerEnter2D(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            collided = true;
        }
    }
    private void OnTriggerExit2D(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collided = false;
        }
    }
}
