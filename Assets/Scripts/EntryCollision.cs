using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryCollision : MonoBehaviour
{
    public GameObject useVehicle;    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            useVehicle.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            useVehicle.SetActive(false);
        }
    }
}
