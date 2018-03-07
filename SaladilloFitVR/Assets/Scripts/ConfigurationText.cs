///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: ConfigurationText.cs
///////////////////////////////

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConfigurationText : MonoBehaviour
{

    #region Declaración de variables

    // Objeto que indica que se ha establecido conexión
    public GameObject connected;
    // Objeto que indica que se no ha establecido conexión
    public GameObject disconnected;
    // Referencia al panel Client
    public GameObject clientPanel;

    #endregion

    #region Métodos

    // Use this for initialization
    void Start()
    {
        if (!PlayerPrefs.GetString(GameManager.IP_ADDRESS).Equals(string.Empty))
        {
            // Se recupera el valor de dirección IP almacenado en la configuracion de la aplicación
            GameManager.ipAddress = PlayerPrefs.GetString(GameManager.IP_ADDRESS);
            // Mostramos la dirección IP
            GetComponent<Text>().text = GameManager.ipAddress;
            // Se comprueba la conectividad con la Web API
            CheckConnectivity();
        } else
        {
            disconnected.SetActive(true);
        }
    }

    /// <summary>
    /// Comprueba si existe conexión con la Web API.
    /// </summary>
    /// <remarks>
    /// Llamar a la corrutina CheckConnectivityWebAPI para comprobar la conexión.
    /// </remarks>
    private void CheckConnectivity()
    {
        StartCoroutine(CheckConnectivityWebAPI());
    }

    /// <summary>
    /// Corrutina que comprueba la conexión con la WebAPI.
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckConnectivityWebAPI()
    {
        // Prepara la petición a la web API
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_CHECK_CONECTIVITY, GameManager.ipAddress))))
        {
            // Hace la petición a la web API
            yield return www.SendWebRequest();

            // Comprueba el valor devuelto por el método
            clientPanel.SetActive(www.responseCode == 200);
            connected.SetActive(www.responseCode == 200);
            disconnected.SetActive(!connected.activeSelf);
        }
    }

    #endregion

}
