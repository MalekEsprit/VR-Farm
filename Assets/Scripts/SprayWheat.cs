using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayWheat : MonoBehaviour
{

    private GameObject dirtPile;
    private bool isDried = false; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlantWheat"))
        {
            StartSpraying(other.gameObject);
        }
        if (other.CompareTag("DirtPile"))
        {
            dirtPile = other.gameObject;
            DryLand();
        }
    }

    private void StartSpraying(GameObject wheat)
    {
        WheatMesh currentPlant = wheat.GetComponent<WheatMesh>();
        if (currentPlant != null)
        {
            currentPlant.Spray(currentPlant.growthStage);

            if(currentPlant.growthStage > 1)
            { isDried = true; }
        }
    }
    private void DryLand()
    {
        if (isDried)
        {
            StartCoroutine(DryTimer(dirtPile));
        }

    }
    private IEnumerator DryTimer(GameObject _dirtPile)
    {
        yield return new WaitForSeconds(12f);
        MeshRenderer dirtMeshRenderer = _dirtPile.GetComponent<MeshRenderer>();
        if (dirtMeshRenderer != null)
        {
            dirtMeshRenderer.enabled = false;
        }
    }
}
