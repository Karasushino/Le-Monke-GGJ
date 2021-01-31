using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPlayerInRange : MonoBehaviour
{
    public Ally AllyScript;
    private bool once = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
                AllyScript.isPlayerInRange = true;
                Debug.Log("Player in range");
              
            


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          
                AllyScript.isPlayerInRange = false;
                Debug.Log("Player out range");
          

       


        }

    }
}
