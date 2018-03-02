///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: LoginText.cs
///////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoginText : MonoBehaviour {

    #region Declaracion de variables

    // Texto donde esta escrito el DNI
    public Text dni;
    // Botones de los ejercicios
    public GameObject trainings;
    // Detalles del ejercicio
    public GameObject details;


    #endregion

    #region Metodos

    // Use this for initialization
    void Start () {
       
	}

    /// <summary>
    /// Comprueba si existe conexion con la Web API
    /// </summary>
    /// <remarks>
    /// Llamar a la corrutina CheckConnectivityWebAPI para comprobar la conexion
    /// </remarks>
    public void Click()
    {
        StartCoroutine(LoginWebAPI());
    }

    IEnumerator LoginWebAPI()
    {
        // Prepara la peticion a la web api
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_LOG_CLIENT, GameManager.localhost, dni.text))))
        {
            // Hace la peticion a la web api
            yield return www.SendWebRequest();
            string result = www.downloadHandler.text;
            if(result.Length > 0)
            { 
                dni.text = result.Substring(1, result.Length-2);
                trainings.SetActive(true);
                details.SetActive(true);
            }
        }
    }

    #endregion

}
