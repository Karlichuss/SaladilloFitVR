///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: SalirButton.cs
///////////////////////////////

using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirButton : MonoBehaviour {

    #region Métodos

    /// <summary>
    /// Acción a realiar cuando se pulse el botón.
    /// </summary>
    public void Click()
    {
        // Cargamos la escena Main
        SceneManager.LoadScene("Main");
    }

    #endregion
}
