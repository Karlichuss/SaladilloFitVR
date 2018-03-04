///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: ClearScript.cs
///////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class ClearScript : MonoBehaviour {

    #region Declaración de variables

    // Objeto con la dirección IP introducida por el usuario
    public Text ipAddress;

    #endregion

    #region Métodos

    /// <summary>
    /// Método que se ejecuta cuando se pulsa en el boton.
    /// </summary>
    /// <remarks>
    /// Borra todo el texto de ipAddress.
    /// </remarks>
    public void Click()
    {
        ipAddress.GetComponent<Text>().text = "";
    }

    #endregion

}
