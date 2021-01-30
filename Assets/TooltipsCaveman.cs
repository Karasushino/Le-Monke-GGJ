using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipsCaveman : MonoBehaviour
{
    public GameObject becomeMonkeSign;
    public GameObject attackSign;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            becomeMonkeSign.SetActive(false);
            attackSign.SetActive(true);
            Destroy(gameObject);
        }
    }


}
