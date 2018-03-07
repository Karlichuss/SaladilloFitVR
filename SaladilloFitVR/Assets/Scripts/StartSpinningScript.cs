///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: StartSpinningScript.cs
///////////////////////////////

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class StartSpinningScript : MonoBehaviour {

    #region Métodos

    /// <summary>
    /// Acción a realizar cuando se entra en el ascensor.
    /// </summary>
    public void UseElevator()
    {
        GameManager.training = 4;
        // Llamamos al método que guarda la información del cliente
        StartCoroutine(LogTrainingtWebAPI());
    }

    /// <summary>
    /// Corrutina que guarda un registro en la WebAPI e inicia el entrenamiento de spinning.
    /// </summary>
    /// <returns></returns>
    IEnumerator LogTrainingtWebAPI()
    {
        // Construimos la información que se envía a la WebAPI
        WWWForm form = new WWWForm();
        form.AddField("dni", GameManager.dni);
        form.AddField("training", GameManager.training);

        // Crea la petición a la WebAPI
        using (UnityWebRequest www = UnityWebRequest.Post(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_LOG_TRAINING, GameManager.ipAddress)), form))
        {
            // Envia la petición a la WebAPI y espera la respuesta
            yield return www.SendWebRequest();

            // Acción a realizar si se ha ejecutado sin error
            if (!www.isNetworkError)
            {
                SceneManager.LoadScene("Spinning");
            }
        }
    }

    #endregion

}
