///////////////////////////////
// Práctica: SaladilloVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: DeleteScript.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteScript : MonoBehaviour {

    #region Declaracion de variables

    // Objeto con la direccion IP introducida por el usuario
    public Text ipAddress;

    #endregion

    #region Metodos

    /// <summary>
    /// Metodo que se ejecuta cuando se pulsa en el boton
    /// </summary>
    /// <remarks>
    /// Borra todo el texto de ipAddress
    /// </remarks>
    public void Click()
    {
        string texto = ipAddress.GetComponent<Text>().text;

        if (texto.Length > 0)
        {
            ipAddress.GetComponent<Text>().text = texto.Substring(0, texto.Length - 1);
        }
    }

    #endregion

}
