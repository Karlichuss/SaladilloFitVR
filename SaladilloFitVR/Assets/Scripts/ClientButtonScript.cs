///////////////////////////////
// Práctica: SaladilloVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: ClientButtonScript.cs
///////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ClientButtonScript : MonoBehaviour {

    #region Metodos

    public void Click()
    {
        // Llamamos al metodo que guarda la informacion del cliente
        LogClient();
    }

    /// <summary>
    /// Guarda la informacion del cliente
    /// </summary>
    /// <remarks>
    /// Llama a la corrutina que conecta con la WebAPI para guardar la informacion
    /// </remarks>
    private void LogClient()
    {
        StartCoroutine(LogClientWebAPI());
    }

    IEnumerator LogClientWebAPI()
    {
        // Construimos la informacion que se envia a la WebAPI
        WWWForm form = new WWWForm();
        form.AddField("dni", GetComponentInChildren<Text>().text.Split('-')[0].Trim());
        form.AddField("name", GetComponentInChildren<Text>().text.Split('-')[1].Trim());

        // Crea la peticion a la WebAPI
        using (UnityWebRequest www = UnityWebRequest.Post(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_LOG_CLIENT, GameManager.ipAddress)), form))
        {
            // Envia la peticion a la WebAPI y espera la respuesta
            yield return www.SendWebRequest();

            // Accion a realizar si se ha ejecutado son error
            if (!www.isNetworkError)
            {
                // Se accede al AudioSource del padre y se reproduce
                GetComponentInParent<AudioSource>().Play();
            }
        }
    }

    #endregion

}
