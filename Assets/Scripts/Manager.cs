using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject mobileButtons;
    //private bool isMobilePlatform;

    public GameObject playerObject;

    private void Start()
    {
        //Resolution currentResolution = Screen.currentResolution;
        //RefreshRate refresh = currentResolution.refreshRateRatio;

        Application.targetFrameRate = Application.isMobilePlatform ? 60 : 300; //TODO: Set the target frame rate here for PC

        // Verifica si el objeto tiene el componente necesario
        if (playerObject != null)
        {
            PrometeoCarController prometeoCarController = playerObject.GetComponent<PrometeoCarController>();

            if (prometeoCarController != null)
            {
                // Actualiza la visibilidad de los botones móviles y cambia los controles
                UpdateMobileButtonsVisibility(Application.isMobilePlatform);
            }
            else
            {
                Debug.LogError("El objeto con la etiqueta 'Player' no tiene el componente PrometeoCarController.");
            }
        }
        else
        {
            Debug.LogError("No se encontró ningún objeto con la etiqueta 'Player'.");
        }
    }

    private void Update()
    {
        // Comprueba si es un móvil y actualiza la visibilidad de los botones
        UpdateMobileButtonsVisibility(Application.isMobilePlatform);
    }

    private void UpdateMobileButtonsVisibility(bool isMobile)
    {
        mobileButtons.SetActive(isMobile);

        // Cambia los controles solo si el objeto y el componente son válidos
        if (playerObject != null)
        {
            PrometeoCarController prometeoCarController = playerObject.GetComponent<PrometeoCarController>();

            if (prometeoCarController != null)
            {
                prometeoCarController.changeControllsType(isMobile);
            }
            else
            {
                Debug.LogError("El objeto con la etiqueta 'Player' no tiene el componente PrometeoCarController.");
            }
        }
        else
        {
            Debug.LogError("playerObject es null en UpdateMobileButtonsVisibility.");
        }
    }
}
