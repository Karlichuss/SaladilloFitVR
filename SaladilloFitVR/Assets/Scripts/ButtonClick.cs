///////////////////////////////
// Práctica: SaladilloVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: ButtonClick.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour {

    #region Declaracion de variables

    // GameObject que se modifica cuando se pulsa el boton
    public GameObject clickObject;

    #endregion

    #region Metodos

    public void Click()
    {
        // Si el objeto esta activo, se desactiva y viceversa
        clickObject.SetActive(!clickObject.activeSelf);
    }

    #endregion
}
