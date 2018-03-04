///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: StartTrainingScript.cs
///////////////////////////////

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class StartTrainingScript : MonoBehaviour
{

    #region Métodos

    /// <summary>
    /// Acción a realizar cuando se hace click en el botón.
    /// </summary>
    public void Click()
    {
        StartCoroutine(StartTraining());
    }

    /// <summary>
    /// Corrutina que realiza un registro en el Log de la WebAPI e inicia la escena Machines.
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartTraining()
    {
        // Construimos la información que se envía a la WebAPI
        WWWForm form = new WWWForm();
        form.AddField("dni", GameManager.dni);
        form.AddField("training", GameManager.training);

        // Crea la petición a la WebAPI
        using (UnityWebRequest www = UnityWebRequest.Post(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_LOG_TRAINING_LOCAL, GameManager.localhost)), form))
        {
            // Envia la petición a la WebAPI y espera la respuesta
            yield return www.SendWebRequest();

            // Acción a realizar si se ha ejecutado sin error
            if (!www.isNetworkError)
            {
                SceneManager.LoadScene("Machines");
            }
        }
    }

    #endregion
}
