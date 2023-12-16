using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class PlayScene : MonoBehaviour
{
    public XRJoystick vh1;
    public XRJoystick vh2;
    public XRJoystick vh3;
    public XRJoystick vh4;

    public GameObject sp1;
    public GameObject sp2;

    public GameObject[] spayers;
    public XRJoystick svh1;
    public XRJoystick svh2;
    public XRJoystick svh3;

    private Vector2 init = new Vector2(0, 1);

    private void Start()
    {
        sp1.SetActive(true); sp2.SetActive(true);
        StartCoroutine(LaunchVehicle());
    }

    private IEnumerator LaunchVehicle()
    {
        vh1.value = init;
        yield return new WaitForSeconds(2f);
        vh2.value = init;
        yield return new WaitForSeconds(2f);
        vh3.value = init;
        yield return new WaitForSeconds(2f);
        vh4.value = init;
        yield return new WaitForSeconds(15f);
        spayers[0].SetActive(true);
        yield return new WaitForSeconds(1f);
        svh1.value = init;
        yield return new WaitForSeconds(5f);
        spayers[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        svh2.value = init;
        yield return new WaitForSeconds(5f);
        spayers[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        svh3.value = init;
    }
}
