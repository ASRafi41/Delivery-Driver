using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Trigger entered with: " + collision.gameObject.name);
        if(collision.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Package delivered: " + collision.gameObject.name);
             Destroy(collision.gameObject); // Destroy the package on delivery
        }
        else if (collision.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            Debug.Log("Package delivered: " + collision.gameObject.name);
            // Destroy(collision.gameObject); // Destroy the package on delivery
        }
    }
}
