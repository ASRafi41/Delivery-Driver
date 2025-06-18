using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32((byte)0.4862745, (byte)0.9882354f, 0, 1); // Green color when has package
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1); // Green color when has package

    bool hasPackage = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
    }

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Trigger entered with: " + collision.gameObject.name);
        if(collision.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Package delivered: " + collision.gameObject.name);
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject); // Destroy the package on delivery
        }
        else if (collision.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            Debug.Log("Package delivered: " + collision.gameObject.name);
            spriteRenderer.color = noPackageColor;
            // Destroy(collision.gameObject); // Destroy the package on delivery
        }
    }
}
