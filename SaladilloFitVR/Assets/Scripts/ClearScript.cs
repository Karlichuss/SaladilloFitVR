///////////////////////////////
// Práctica: SaladilloVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: ClearScript.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearScript : MonoBehaviour {

    #region Declaracion de variables

    // Objeto con la direccion IP instroducida por el usuario
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
        ipAddress.GetComponent<Text>().text = "";
    }

    #endregion

}
