using UnityEngine;

public class DeleteObjectsOnCollision : MonoBehaviour
{
    // Se ejecuta cuando un objeto colisiona con el collider
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisionó tiene un componente Rigidbody (puedes ajustar esto según tus necesidades)
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Destruye el objeto que colisionó
            Destroy(other.gameObject);
        }
    }
}
