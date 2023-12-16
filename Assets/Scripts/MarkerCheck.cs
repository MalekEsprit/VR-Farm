using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerCheck : MonoBehaviour
{
    public bool test = false;


    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            Check();
            test = false;
        }
        
    }

    private void Check()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.GetComponent<WheatSpawner>().ActivateAllWheatMarkers();
        }
    }
}
