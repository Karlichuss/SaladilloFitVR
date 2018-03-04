///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: WriterScript.cs
///////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class WriterScript : MonoBehaviour
{

    #region Declaración de variables

    // Objeto con la dirección IP introducida por el usuario
    public Text ipAddress;

    #endregion

    #region Métodos

    /// <summary>
    /// Método que se ejecuta cuando se pulsa en el botón.
    /// </summary>
    /// <remarks>
    /// Obtiene el texto del botón y se lo concatena al texto de ipAddress.
    /// </remarks>
    public void Click()
    {
        ipAddress.GetComponent<Text>().text += GetComponentInChildren<Text>().text;
    }

    #endregion

}