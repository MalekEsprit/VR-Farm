using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatSpawner : MonoBehaviour
{
    public GameObject wheatPrefab;
    public List<GameObject> dirtPiles;
    public int minWheatCount = 5;
    public int maxWheatCount = 8;


    private List<GameObject> spawnedWheatObjects = new List<GameObject>();

    void Start()
    {
        SpawnWheatInDirtPiles();
    }

    void SpawnWheatInDirtPiles()
    {
        foreach (GameObject dirtPile in dirtPiles)
        {
            if (dirtPile != null)
            {
                SpawnWheatInDirtPile(dirtPile);
            }
        }
    }
    public void ActivateAllWheatMarkers()
    {
        foreach (GameObject wheat in spawnedWheatObjects)
        {
            Transform marker = wheat.transform.GetChild(0); 
            if (marker != null)
            {
                if(!wheat.CompareTag("CuttedWheat"))
                { marker.gameObject.SetActive(true); }              
            }
        }
    }

    void SpawnWheatInDirtPile(GameObject dirtPile)
    {
        Bounds bounds = GetColliderBounds(dirtPile);

        int wheatCount = Random.Range(minWheatCount, maxWheatCount + 1);

        for (int i = 0; i < wheatCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y - 0.2f),
                Random.Range(bounds.min.z, bounds.max.z)
            );

            GameObject wheat = Instantiate(wheatPrefab, randomPosition, Quaternion.identity, dirtPile.transform);
            spawnedWheatObjects.Add(wheat);
        }
    }

    Bounds GetColliderBounds(GameObject obj)
    {
        Collider[] colliders = obj.GetComponentsInChildren<Collider>();
        if (colliders.Length > 0)
        {
            Bounds bounds = colliders[0].bounds;
            foreach (Collider collider in colliders)
            {
                bounds.Encapsulate(collider.bounds);
            }
            return bounds;
        }
        else
        {
            // Default bounds if no colliders are found
            return new Bounds(obj.transform.position, Vector3.one);
        }
    }
}
