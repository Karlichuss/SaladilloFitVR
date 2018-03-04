///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: SaveScript.cs
///////////////////////////////

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveScript : MonoBehaviour
{

    #region Declaración de variables

    // Objeto con la dirección IP introducida por el usuario
    public Text ipAddress;

    // Objeto que indica que se ha establecido conexión
    public GameObject connected;

    // Objeto que indica que se no ha establecido conexión
    public GameObject disconnected;

    // Referencia al panel Client
    public GameObject clientPanel;

    #endregion

    #region Métodos

    /// <summary>
    /// Método que se ejecuta cuando se pulsa en el botón Save.
    /// </summary>
    /// <remarks>
    /// Obtiene la dirección IP introducida por el usuario y la guarda en las preferencias de la aplicación.
    /// </remarks>
    public void Click()
    {
        // Se obtiene la dirección IP introducida por el usuario
        GameManager.ipAddress = ipAddress.GetComponent<Text>().text;
        // Se guarda la dirección IP
        PlayerPrefs.SetString(GameManager.IP_ADDRESS, GameManager.ipAddress);
        // Se almacena el valor en la configuración de la aplicación
        PlayerPrefs.Save();
        // Se comprueba la conectividad con la WebAPI
        CheckConnectivity();
    }

    /// <summary>
    /// Comprueba si existe conexión con la WebAPI.
    /// </summary>
    /// <remarks>
    /// Llamar a la corrutina CheckConnectivityWebAPI para comprobar la conexión.
    /// </remarks>
    private void CheckConnectivity()
    {
        StartCoroutine(CheckConnectivityWebAPI());
    }

    /// <summary>
    /// Corrutina que comprueba la conectividad con la WebAPI.
    /// </summary>
    /// <returns></returns>
    IEnumerator CheckConnectivityWebAPI()
    {
        // Prepara la petición a la WebAPI
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_CHECK_CONECTIVITY, GameManager.ipAddress))))

        //using (UnityWebRequest www = UnityWebRequest.Get(
        //    Uri.EscapeUriString(string.Format(GameManager.WEB_API_CHECK_CONECTIVITY_LOCAL, GameManager.localhost))))
        {
            // Hace la petición a la WebAPI
            yield return www.SendWebRequest();

            // Comprueba el valor devuelto por el método
            clientPanel.SetActive(www.responseCode == 200);
            connected.SetActive(www.responseCode == 200);
            disconnected.SetActive(!connected.activeSelf);
        }
    }

    #endregion

}
