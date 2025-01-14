using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    private int movementX;
    private int movementZ;
    public int targetX, targetZ = 0;
                            
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetX = (int)rb.position.x;
        targetZ = (int)rb.position.z;

    }
    void OnMove(InputValue movementValue)
    {
        if ((int)rb.position.x == targetX && (int)rb.position.z == targetZ)
        {
            // Store the value of the movement input
            Vector2 movementVector = movementValue.Get<Vector2>();

            movementX = (int)movementVector.x;
            movementZ = (int)movementVector.y;

            targetX = (int)rb.position.x + movementX;
            targetZ = (int)rb.position.y + movementZ;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("targetX: " + targetX + " targetZ: " + targetZ);
        Debug.Log("rb.position.x: " + rb.position.x + " rb.position.z: " + rb.position.z);
        if (rb.position.x != targetX || rb.position.y != targetZ)
        {
            // animate rb moving towards target position
            Vector3 movement = new Vector3(movementX, 0.0f, movementZ);
            rb.AddForce(movement);
        }
        else
        {
            rb.AddForce(-rb.GetAccumulatedForce());
        }
    }
}
