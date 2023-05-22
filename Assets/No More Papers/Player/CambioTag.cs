using UnityEngine;

public class CambioTag : MonoBehaviour
{
    public string nuevoTag = "Invisible";
    private string tagInicial;
    private bool dentroDelComponente = false;

    private void Start()
    {
        tagInicial = gameObject.tag;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Papel"))
        {
            dentroDelComponente = true;
            CambiarTag(nuevoTag);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Papel"))
        {
            dentroDelComponente = false;
            CambiarTag(tagInicial);
        }
    }

    private void Update()
    {
        /*
        if (dentroDelComponente && !EstasCompletamenteDentro())
        {
            Debug.Log("Hi");
            dentroDelComponente = false;
            CambiarTag(tagInicial);
        }
        */
    }

    private bool EstasCompletamenteDentro()
    {
        Collider2D collider2D = GetComponent<Collider2D>();
        Bounds bounds = collider2D.bounds;
        Collider2D[] colliders = Physics2D.OverlapAreaAll(bounds.min, bounds.max);
        foreach (Collider2D collider in colliders)
        {
            if (!collider.CompareTag("Papel"))
            {
                return false;
            }
        }
        return true;
    }

    private void CambiarTag(string nuevoTag)
    {
        gameObject.tag = nuevoTag;
    }
}
