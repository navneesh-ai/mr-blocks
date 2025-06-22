using UnityEngine;
 using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{

    private float horizontalInput, verticalInput;
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame after the Start function
    void Update()
    {
       GetInput();
       MovePlayer();
    }

    private void GetInput() 
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
       // Debug.Log("Horizontal input: " + horizontalInput + " Vertical input: " + verticalInput);
    }

    private void MovePlayer()
    {
        //transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime);
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        // .normalized is used to make the distance travelled in all direction equal
        Vector3 moveAmount = moveDirection.normalized * speed * Time.deltaTime;
        transform.position += moveAmount;
    }
}
