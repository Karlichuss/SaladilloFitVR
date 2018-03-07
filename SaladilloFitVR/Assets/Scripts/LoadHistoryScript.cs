///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: LoadHistoryScript.cs
///////////////////////////////

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadHistoryScript : MonoBehaviour
{

    #region Declaración de variables

    // Referencia al texto donde pondremos el resultado de la consulta
    public GameObject history;
    // Referencia al Prefab que sea el hijo que se instancie
    public GameObject historyItem;

    #endregion

    #region Métodos

    /// <summary>
    /// Acción a seguir cuando se hace click en el botón.
    /// </summary>
    /// <remarks>
    /// Llama a la corrutina que obtiene de la WebAPI el histórico del usuario.
    /// </remarks>
    public void Click()
    {
        StartCoroutine(GetHistory());
    }

    /// <summary>
    /// Corrutina que muestra el historial del usuario.
    /// </summary>
    /// <returns></returns>
    IEnumerator GetHistory()
    {
        // Preparamos la petición a la WebAPI
        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_HISTORY, GameManager.ipAddress, GameManager.dni))))
        {
            // Hace la petición a la WebAPI
            yield return www.SendWebRequest();
            HistoryList list = JsonUtility.FromJson<HistoryList>(www.downloadHandler.text);

            // Destruimos todos los hijos de historico
            int childs = history.transform.childCount;
            for (int i = childs - 1; i > 0; i--)
            {
                Destroy(history.transform.GetChild(i).gameObject);
            }

            // Y si la WebAPI nos da alguna respuesta
            if (list.history.Length != 0)
            {
                // Y por cada ejercicio que tenga el entrenamiento
                for (int i = 0; i < list.history.Length; i++)
                {

                    // Se crea el objeto para el item
                    GameObject item = Instantiate(historyItem);

                    // Se asigna el texto que debe mostrar
                    item.GetComponentInChildren<Text>().text = string.Format("{0} - Comienzo: {1} - Fin: {2}",list.history[i].training, list.history[i].start, list.history[i].end);

                    // Se establece su padre que esta en la escena
                    item.transform.SetParent(history.transform);

                    // Se asigna la escala del item
                    item.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);

                    // Se posiciona en la escena
                    item.GetComponent<RectTransform>().localPosition = new Vector3(0, -((i + 1) * 20), 0);
                }
            }
            history.GetComponentInChildren<Text>().text = "";
        }
    }

    #endregion

    #region Entidades

    public class HistoryList
    {
        // Es importante que el nombre de esta variable coincida con el padre de lo que te dan en Postman
        public History[] history;
    }

    [Serializable]
    public class History
    {
        public string training;
        public string start;
        public string end;
    }

    #endregion
}
