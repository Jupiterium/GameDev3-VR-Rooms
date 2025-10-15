using UnityEngine;

public class FanBladesSpin : MonoBehaviour
{
    // Speed of the rotation of the blades
    public float rotationSpeed = 5f;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
