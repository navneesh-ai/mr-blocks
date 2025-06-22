using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    public float rotationSpeed = 90f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        RotateSpikeBall();
    }

     private void RotateSpikeBall()
     {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
     }
}
