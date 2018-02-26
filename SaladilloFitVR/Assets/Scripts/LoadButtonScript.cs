///////////////////////////////
// Práctica: SaladilloVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: LoadButtonScript.cs
///////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadButtonScript : MonoBehaviour
{

    #region Declaracion de variables

    // Objeto donde se va a crear la informacion de los clientes
    public GameObject information;

    // Objeto que se crea para un cliente
    public GameObject client;

    #endregion

    #region Metodos

    /// <summary>
    /// Metodo que se ejecuta cuando se pulsa el boton Load
    /// </summary>
    public void Click()
    {
        GetClients();
    }

    /// <summary>
    /// Obtiene la lista de clientes
    /// </summary>
    /// <remarks>
    /// Llama una corrutina que conecta con la Web API para obtener la informacion
    /// </remarks>
    private void GetClients()
    {
        StartCoroutine(GetClientsWebAPI());
    }

    IEnumerator GetClientsWebAPI()
    {
        // Se crea la peticion a la WebAPI
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_CLIENTS, GameManager.ipAddress))))
        {
            // Envia la peticion a la WebAPI y espera la respuesta
            yield return www.SendWebRequest();

            // Accion a realiza r si la peticion se ha realizado sin error
            if (!www.isNetworkError)
            {
                // Se recupera la lista de clientes
                ClientList clientList = JsonUtility.FromJson<ClientList>(www.downloadHandler.text);

                // Recorre la lista de clientes
                for (int i = 0; i < clientList.clients.Length; i++)
                {
                    // Se crea el objeto para un cliente
                    GameObject clientItem = Instantiate(client);

                    // Se asigna el texto que debe mostrar
                    clientItem.GetComponentInChildren<Text>().text = clientList.clients[i].dni + " - " + clientList.clients[i].name;

                    // Se establece su padre que esta en la escena
                    clientItem.transform.SetParent(information.transform);

                    // Se posiciona en la escena
                    clientItem.GetComponent<RectTransform>().localPosition = new Vector3(0, (-0.13f) * (i + 1), 0);

                }
            }
        }
    }

    #endregion

    #region Entidades

    public class ClientList
    {
        // Es importante que el nombre de esta variable coincida con el padre de lo que te dan en Postman
        public Client[] clients;
    }

    [Serializable]
    public class Client
    {
        public string dni;
        public string name;
    }

    #endregion

}
