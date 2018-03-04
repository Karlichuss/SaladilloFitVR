///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: TrainingButtonScript.cs
///////////////////////////////

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TrainingButtonScript : MonoBehaviour {

    #region Declaración de variables

    // Entero que corresponde con el numero del entrenamiento
    public int training;

    // Texto donde vamos a mostrar el detalle del entrenamiento
    public GameObject trainingItem;

    // Texto donde vamos a mostrar el titulo de los detalles
    public GameObject detail;

    #endregion

    #region Métodos

    /// <summary>
    /// Acción a realizar cuando se hace click en el botón.
    /// </summary>
    public void Click()
    {
        // Llamamos al método que guarda la información del cliente
        LogButton();
    }

    /// <summary>
    /// Guarda la información del cliente.
    /// </summary>
    /// <remarks>
    /// Llama a la corrutina que conecta con la WebAPI para guardar la información.
    /// </remarks>
    private void LogButton()
    {
        StartCoroutine(LogTrainingtWebAPI());
    }

    /// <summary>
    /// Corrutina que muestra los ejercicios que forman parte del entrenamiento seleccionado.
    /// </summary>
    /// <returns></returns>
    IEnumerator LogTrainingtWebAPI()
    {
        // Preparamos la petición a la WebAPI
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_TRAINING_LOCAL, GameManager.localhost, training))))
        {
            // Hace la petición a la WebAPI
            yield return www.SendWebRequest();
            TrainingtList list = JsonUtility.FromJson<TrainingtList>(www.downloadHandler.text);

            // Destruimos todos los hijos de detail
            int childs = detail.transform.childCount;
            for (int i = childs - 1; i > 0; i--)
            {
                Destroy(detail.transform.GetChild(i).gameObject);
            }

            // Y si la WebAPI nos da alguna respuesta
            if (list.training.Length != 0)
            {
                detail.SetActive(true);

                // Almacenamos el entrenamiento
                GameManager.training = training;

                // Ponemos el titulo del entrenamiento
                detail.GetComponentInChildren<Text>().text = "Entrenamiento " + training + ": ";

                // Y por cada ejercicio que tenga el entrenamiento
                for (int i = 0; i < list.training.Length; i++)
                {

                    // Se crea el objeto para el item
                    GameObject item = Instantiate(trainingItem);

                    // Se asigna el texto que debe mostrar
                    item.GetComponentInChildren<Text>().text = list.training[i].machine;

                    // Se establece su padre que esta en la escena
                    item.transform.SetParent(detail.transform);

                    // Se asigna la escala del item
                    item.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);

                    // Se posiciona en la escena
                    item.GetComponent<RectTransform>().localPosition = new Vector3(0, -((i+1) * 20), 0);
                }
            }
        }
    }

    #endregion

    #region Entidades
    public class TrainingtList
    {
        // Es importante que el nombre de esta variable coincida con el padre de lo que te dan en Postman
        public Training[] training;
    }

    [Serializable]
    public class Training
    {
        public int training;
        public string machine;
    }

    #endregion

}
