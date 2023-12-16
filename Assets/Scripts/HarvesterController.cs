using UnityEngine;
public class HarvesterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 30f;
    public Transform reel;

    void Update()
    {
        RotateReel();
    }
    void RotateReel()
    {
        float movement = moveSpeed * Time.deltaTime;
        float rotationAmount = movement * rotationSpeed;
        reel.Rotate(Vector3.right, rotationAmount);
        
    }
}
