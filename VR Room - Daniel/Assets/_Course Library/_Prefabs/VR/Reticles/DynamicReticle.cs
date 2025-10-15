using UnityEngine;

public class DynamicReticle : MonoBehaviour
{
    // Variables to control resizing
    public Vector3 minScale = new Vector3(1f, 1f, 1f); // Minimum scale
    public Vector3 maxScale = new Vector3(2f, 2f, 2f); // Maximum scale
    public float speed = 2f; // Speed of resizing

    private Vector3 scaleRange;

    void Start()
    {
        // Calculate the range between max and min scale
        scaleRange = maxScale - minScale;
    }

    void Update()
    {
        // Calculate the scale factor using Mathf.PingPong
        float scaleFactor = Mathf.PingPong(Time.time * speed, 1f);

        // Interpolate between minScale and maxScale
        transform.localScale = minScale + scaleFactor * scaleRange;
    }
}
