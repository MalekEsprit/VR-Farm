using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class UseVehicle : MonoBehaviour
{
    public GameObject playerController;
    public GameObject seatPos;
    public GameObject vehicleSpecial;
    public GameObject uiDesc;
    public GameObject EntryFX;

    public void EnterVehicle()
    {
        playerController.SetActive(false);
        uiDesc.SetActive(true);
        seatPos.SetActive(true);
        EntryFX.SetActive(false);

        StartCoroutine(showUiTimer());
    }
    public void ExitVehicle()
    {
        playerController.SetActive(true);
        seatPos.SetActive(false);
        EntryFX.SetActive(true);
    }
    public void VehicleSpecial()
    {
        if(vehicleSpecial.activeInHierarchy)
        {
            vehicleSpecial.SetActive(false);
        }
        else
        {
            vehicleSpecial.SetActive(true);
        }
    }

    IEnumerator showUiTimer()
    {
        yield return new WaitForSeconds(10f);
        uiDesc.SetActive(false);
    }
}
