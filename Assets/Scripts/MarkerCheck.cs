using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerCheck : MonoBehaviour
{
    private void RunCheck(bool state)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            child.gameObject.GetComponent<WheatSpawner>().CheckForCuttedWheat(state);
        }
    }
    public void ActiveCutMarkers()
    {
        StartCoroutine(MarkersTimer());
    }

    private IEnumerator MarkersTimer()
    {
        RunCheck(true);
        yield return new WaitForSeconds(3f);
        RunCheck(false);
    }
}
