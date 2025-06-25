using UnityEngine;
 using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    private float horizontalInput, verticalInput;
    public float speed = 5f;

    private Rigidbody2D rb;

    private SoundManager soundManager;

    private bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundManager = FindObjectOfType<SoundManager>();
        if (soundManager == null)
        {
            Debug.LogError("SoundManager not found in the scene.");
        }
        isDead = false;
    }

    // Update is called once per frame after the Start function
    private void Update() => GetInput();

    // An Event function called at a fixed time interval, independent of frame rate.
    // It is perfect for physics calculations because it keeps them consistent, even if your game's frame rate varies.
    private void FixedUpdate() => MovePlayer();

    private void GetInput() 
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
       // Debug.Log("Horizontal input: " + horizontalInput + " Vertical input: " + verticalInput);
    }

    private void MovePlayer()
    {
        // Movement using transform.position
        // Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        // Vector3 moveAmount = moveDirection.normalized * speed * Time.deltaTime;
        // transform.position += moveAmount;

        // Movement using Rigidbody2D
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
        rb.linearVelocity = moveDirection.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Collided with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Obstacle"))
        {
            PlayerDied();
        }
    }

   private void PlayerDied()
    {
        if (isDead) return;
        isDead = true;
        soundManager.PlayGameOverAudio();
        LevelManager.Instance.OnPlayerDeath();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
          //  Debug.Log("current scene index: " + LevelManager.Instance.CurrentSceneIndex);
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        soundManager.PlayLevelCompleteAudio();
        LevelManager.Instance.OnLevelComplete();
    }

}
