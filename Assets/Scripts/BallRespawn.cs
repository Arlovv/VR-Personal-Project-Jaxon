using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    private Vector3 initialPosition; // Initial position of the ball
    private Rigidbody rb; // Rigidbody component of the ball

    private void Start()
    {
        initialPosition = transform.position; // Store initial position
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "wall" tag
        if (other.CompareTag("wall"))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        // Find the closest object with the "respawn" tag
        GameObject[] respawnObjects = GameObject.FindGameObjectsWithTag("respawn");
        GameObject closestRespawnObject = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject respawnObject in respawnObjects)
        {
            float distance = Vector3.Distance(transform.position, respawnObject.transform.position);
            if (distance < closestDistance)
            {
                closestRespawnObject = respawnObject;
                closestDistance = distance;
            }
        }

        // If a respawn object is found, respawn the ball there and stop its momentum
        if (closestRespawnObject != null)
        {
            transform.position = closestRespawnObject.transform.position;
            rb.velocity = Vector3.zero; // Stop the ball's velocity
            rb.angularVelocity = Vector3.zero; // Stop the ball's angular velocity
        }
        else
        {
            // If no respawn object is found, respawn the ball at its initial position
            transform.position = initialPosition;
            rb.velocity = Vector3.zero; // Stop the ball's velocity
            rb.angularVelocity = Vector3.zero; // Stop the ball's angular velocity
        }
    }
}