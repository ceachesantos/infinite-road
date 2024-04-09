using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTerrain : MonoBehaviour
{
    public ParticleSystem dirtSmokeLeft;
    public ParticleSystem dirtSmokeRight;
    private PrometeoCarController carControllerScript;
    private ParticleSystem oldSmokeRight;
    private ParticleSystem oldSmokeLeft;
    bool onDirt;

    void Start()
    {
        // Obtén la instancia del script OtherScript asociado al mismo objeto
        carControllerScript = GetComponent<PrometeoCarController>();
        oldSmokeRight = carControllerScript.RRWParticleSystem;
        oldSmokeLeft = carControllerScript.RLWParticleSystem;
    }

    void Update()
    {
        // Emite un rayo hacia abajo desde la posición del coche
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        // Verifica si el rayo colisiona con algún objeto
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // Verifica si el objeto con el que colisiona tiene la etiqueta "Dirt"
            if (hit.collider.CompareTag("Dirt"))
            {
                Debug.Log("On Dirt");
                onDirt = true;
                //TODO: guardar una copia de las particulas anteriores para volver a restaurarlas
                carControllerScript.RLWParticleSystem = dirtSmokeLeft;
                carControllerScript.RRWParticleSystem = dirtSmokeRight;
            }
            if (hit.collider.CompareTag("Asphalt"))
            {
                Debug.Log("On Asphalt");
                onDirt = false;
                dirtSmokeLeft.Stop();
                dirtSmokeRight.Stop();
                carControllerScript.RRWParticleSystem = oldSmokeRight;
                carControllerScript.RLWParticleSystem = oldSmokeLeft;
            }
            if (onDirt)
            {
                dirtSmokeLeft.Play();
                dirtSmokeRight.Play();
            }else{
                dirtSmokeLeft.Stop();
                dirtSmokeRight.Stop();
            }
        }
    }
}