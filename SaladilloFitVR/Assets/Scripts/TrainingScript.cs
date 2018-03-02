using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TrainingScript : MonoBehaviour {

    // Texto de boton que pulsamos. De este extraemos el numero de entrenamiento que es
    public Text training;

    // Texto donde vamos a mostrar el detalle del entrenamiento
    public Text machines;

    private int cad;

    private void Start()
    {
        training = GetComponent<Text>();
    }

    public void Click()
    {
        // Llamamos al metodo que guarda la informacion del cliente
        LogButton();
    }

    /// <summary>
    /// Guarda la informacion del cliente
    /// </summary>
    /// <remarks>
    /// Llama a la corrutina que conecta con la WebAPI para guardar la informacion
    /// </remarks>
    private void LogButton()
    {
        StartCoroutine(LogTrainingtWebAPI());
    }

    IEnumerator LogTrainingtWebAPI()
    {
        // Prepara la peticion a la web api
        cad = Int32.Parse(tag);

        using (UnityWebRequest www = UnityWebRequest.Get(
            Uri.EscapeUriString(string.Format(GameManager.WEB_API_GET_TRAINING_LOCAL, GameManager.localhost, cad))))
        {
            // Hace la peticion a la web api
            yield return www.SendWebRequest();
            TrainingtList list = JsonUtility.FromJson<TrainingtList>(www.downloadHandler.text);
            machines.text = "Entrenamiento " + tag +": ";
            for (int i = 0; i < list.training.Length; i++)
            {
                machines.text += ("\n" + list.training[i].machine);
            }
        }
    }

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
}
