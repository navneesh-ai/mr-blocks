using UnityEngine;

public class SpikeBall_Scaling : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float scaleSpeed = 1f;
    public Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 maxScale = new Vector3(1.5f, 1.5f, 1.5f);
    public float pauseDuration = 1f;
    public float triggerDistance = 10f;

    private enum ScalingState { ScalingUp, PausedAtMax, ScalingDown, PausedAtMin }
    private ScalingState currentState;

    private float pauseTimer;
    private Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // The player GameObject must have the "Player" tag for this to work.
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }

        transform.localScale = minScale;
        currentState = ScalingState.ScalingUp;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null)
        {
            return; // Don't do anything if the player isn't found.
        }

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= triggerDistance)
        {
            RotateSpikeBall();
            ScaleSpikeBall();
        }
        else
        {
            ResetState();
        }
    }

    private void RotateSpikeBall()
    {
        transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    }

    private void ResetState()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, minScale, scaleSpeed * Time.deltaTime);
        currentState = ScalingState.ScalingUp;
        pauseTimer = 0;
    }

    private void ScaleSpikeBall()
    {
        switch (currentState)
        {
            case ScalingState.ScalingUp:
                transform.localScale = Vector3.MoveTowards(transform.localScale, maxScale, scaleSpeed * Time.deltaTime);
                if (transform.localScale == maxScale)
                {
                    currentState = ScalingState.PausedAtMax;
                    pauseTimer = pauseDuration;
                }
                break;

            case ScalingState.PausedAtMax:
                pauseTimer -= Time.deltaTime;
                if (pauseTimer <= 0f)
                {
                    currentState = ScalingState.ScalingDown;
                }
                break;

            case ScalingState.ScalingDown:
                transform.localScale = Vector3.MoveTowards(transform.localScale, minScale, scaleSpeed * Time.deltaTime);
                if (transform.localScale == minScale)
                {
                    currentState = ScalingState.PausedAtMin;
                    pauseTimer = pauseDuration;
                }
                break;

            case ScalingState.PausedAtMin:
                pauseTimer -= Time.deltaTime;
                if (pauseTimer <= 0f)
                {
                    currentState = ScalingState.ScalingUp;
                }
                break;
        }
    }
}
