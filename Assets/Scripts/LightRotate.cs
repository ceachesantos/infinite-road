using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotate : MonoBehaviour
{
    public float dayDurationMinutes = 10f; // Duración total del día en minutos
    public float initialXRotation = 90f;  // Ángulo inicial en el eje X
    private bool lightsON = false;
    public GameObject lightLeft;
    public GameObject lightRight;
    public GameObject lightRears;
    
    void Update()
    {
        // Obtener el tiempo actual en segundos desde el inicio del juego
        float currentTime = Time.time;

        // Calcular el ángulo de rotación en el eje X basado en el tiempo actual
        float xRotation = initialXRotation + Mathf.Repeat(currentTime / (dayDurationMinutes * 60f), 1f) * 360f;
        //Debug.Log(xRotation);

        if(xRotation > 160f && xRotation < 380)
        {
            lightsON = true;
            lightRight.SetActive(true);
            lightLeft.SetActive(true);
            lightRears.SetActive(true);
        }
        else
        {
            lightsON = false;
            lightRight.SetActive(false);
            lightLeft.SetActive(false);
            lightRears.SetActive(false);
        }

        // Aplicar la rotación a la luz (ajusta los ejes según tu configuración)
        transform.rotation = Quaternion.Euler(xRotation, 90f, 90f);
    }

    public bool getLightsON(){
        return lightsON;
    }
}
