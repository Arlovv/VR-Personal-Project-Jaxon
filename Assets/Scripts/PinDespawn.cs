using UnityEngine;
using System.Collections;

public class BallCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pin"))
        {
            StartCoroutine(DestroyPinsAfterDelay(5f)); // Start coroutine to destroy pins after 5 seconds
        }
    }

    IEnumerator DestroyPinsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for 5 seconds

        GameObject[] pins = GameObject.FindGameObjectsWithTag("Pin");

        // Check each pin's x rotation
        foreach (GameObject pin in pins)
        {
            if (pin.transform.rotation.eulerAngles.x != -90f)
            {
                Destroy(pin); // Destroy the pin if its x rotation is not -90
            }
        }
    }
}