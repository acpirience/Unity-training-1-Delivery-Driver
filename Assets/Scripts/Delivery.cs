using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false;
    [SerializeField] float timeToDisapear = 1f;
    [SerializeField] Color32 hasPackageColor;
    [SerializeField] Color32 notHasPackageColor;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = notHasPackageColor;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Aie : " + collision.GetHashCode());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.tag == "Package" && ! hasPackage)
        {
            Debug.Log("Package ramassé : " + collision.GetHashCode());
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, timeToDisapear);
        }
        if (collision.tag == "Customer")
        {
            if (hasPackage) 
            {
                Debug.Log("Package délivré au client : " + collision.GetHashCode());
                hasPackage = false;
                spriteRenderer.color = notHasPackageColor;
            }
            else
            {
                Debug.Log("Pas de package ...");
            }

        }
    }

}
