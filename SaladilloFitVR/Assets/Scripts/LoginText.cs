///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: LoginText.cs
///////////////////////////////

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoginText : MonoBehaviour
{

    #region Declaración de variables

    // Texto donde esta escrito el DNI
    public Text dni;
    // Botones de los ejercicios
    public GameObject trainings;
    // Detalles del ejercicio
    public GameObject details;
    // Mensaje de bienvenida
    public Text welcome;

    #endregion

    #region Métodos

    /// <summary>
    /// Comprueba si existe conexión con la Web API.
    /// </summary>
    /// <remarks>
    /// Llamar a la corrutina CheckConnectivityWebAPI para comprobar la conexión.
    /// </remarks>
    public void Click()
    {
        GameManager.dni = dni.text;
        StartCoroutine(LoginWebAPI());
    }

    /// <summary>
    /// Corrutina que devuelve el nombre del usuario a partir de su DNI.
    /// </summary>
    /// <returns></returns>
    IEnumerator LoginWebAPI()
    {
        // Prepara la petición a la web api
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_CLIENT, GameManager.ipAddress, dni.text))))

        //using (UnityWebRequest www = UnityWebRequest.Get(
        //    Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_CLIENT_LOCAL, GameManager.localhost, dni.text))))
        {
            // Hace la petición a la web api
            yield return www.SendWebRequest();
            string result = www.downloadHandler.text;

            // Si no existe el usuario
            if (result.Equals("\"\""))
            {
                GameManager.name = "";
                welcome.text = "Bienvenid@ a SaladilloFitVR";
                trainings.SetActive(false);
                details.SetActive(false);
            }
            // Si existe el usuario
            else if (result.Length > 0)
            {
                GameManager.name = result.Substring(1, result.Length - 2);
                dni.text = GameManager.name;
                welcome.text = string.Format("Hola {0}", GameManager.name);
                trainings.SetActive(true);
                details.SetActive(true);
            }
        }
    }

    #endregion

}
