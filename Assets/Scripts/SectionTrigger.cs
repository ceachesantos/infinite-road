using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public List<GameObject> roadSections;  // Lista de prefabs de roadSection
    
    private float lastTriggerTime;
    private int count = 1;
    private bool firstRoadSection = true;

    void OnTriggerEnter(Collider other)
    {
        // Verificar si ha pasado más de 1 segundo desde la última ejecución
        if (Time.time - lastTriggerTime > 1f)
        {
            // Elegir un prefab de manera aleatoria
            GameObject selectedRoadSection = roadSections[Random.Range(0, roadSections.Count)];
            Debug.Log("selectedRoadSection: " + selectedRoadSection.name);

            // Instanciar el objeto y almacenar la referencia
            Debug.Log("count for instantiate: " + count);
            GameObject newRoadSection = Instantiate(selectedRoadSection, new Vector3(0, 0, 150 + GameObject.Find("Terrain" + (count - 1)).transform.Find("ReferencePoint").position.z), Quaternion.identity);
            
            // Cambiar el nombre del objeto instanciado
            newRoadSection.name = "Terrain" + count;

            Debug.Log("Triggered by " + newRoadSection.name);

            // Actualizar el tiempo de la última ejecución
            lastTriggerTime = Time.time;
            int indexToDelete = count - 2;
            count += 1;

            // Eliminar el objeto con nombre X-2
            Debug.Log("Index to delete: " + indexToDelete);
            if (indexToDelete >= 0)
            {
                string nameToDelete = "Terrain" + indexToDelete;
                GameObject objToDelete = GameObject.Find(nameToDelete);

                if (objToDelete != null)
                {
                    Debug.Log("Deleting: " + nameToDelete);
                    Destroy(objToDelete);
                }
            }
        }
        else
        {
            Debug.Log("Too soon!");
        }
    }
}
