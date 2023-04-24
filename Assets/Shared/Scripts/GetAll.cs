using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAll : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            activate();
        }
    }

    private void activate()
    {
        foreach (Collectables collectables in FindObjectsOfType<Collectables>())
        {
            collectables.getAll();
        }
    }
}
