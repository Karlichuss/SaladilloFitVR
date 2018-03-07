///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: LoadMachine.cs
///////////////////////////////

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadMachine : MonoBehaviour
{

    #region Métodos

    /// <summary>
    /// Método que se inicia antes del Start.
    /// </summary>
    /// <remarks>
    /// Llama a la corrutina que obtiene de la WebAPI la lista de ejercicios, y activa las maquinas necesarias para que este ejericico se pueda realizar.
    /// </remarks>
    private void Awake()
    {
        StartCoroutine(LoadTrainingInstructions());
    }

    /// <summary>
    /// Corrutina que activa las maquinas que forman parte del entrenamiento seleccionado.
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadTrainingInstructions()
    {
        bool activar = false;

        // Preparamos la petición a la WebAPI
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_TRAINING, GameManager.ipAddress, GameManager.training))))
        {
            // Hace la petición a la WebAPI
            yield return www.SendWebRequest();
            TrainingtList list = JsonUtility.FromJson<TrainingtList>(www.downloadHandler.text);

            // Y si la WebAPI nos da alguna respuesta
            if (list.training.Length != 0)
            {
                // Recorremos los entrenamientos
                for (int i = 0; i < list.training.Length; i++)
                {
                    // Y si esta maquina se encuentra dentro del entrenamiento, lo activamos
                    if (list.training[i].machine.Equals(tag))
                    {
                        activar = true;
                    }
                }
            }
        }

        gameObject.SetActive(activar);

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
