///////////////////////////////
// Práctica: SaladilloVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: SphereScript.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour {

    #region Declaración de variables

    // Material de la esfera cuando no esta siendo mirada
    public Material sphereMaterial;
    // Material de la esfera cuado esta siendo mirada
    public Material sphereHoverMaterial;

    #endregion

    #region Métodos

    // Use this for initialization
    void Start () {
        GetComponent<Renderer>().material = sphereMaterial;
	}

    /// <summary>
    /// Método que es llamado cuando se mira a la esfera
    /// </summary>
    /// <remarks>
    /// Cambia el material de la esfera al correspondiente
    /// </remarks>
    public void HoveredSphere()
    {
        GetComponent<Renderer>().material = sphereHoverMaterial;
    }

    /// <summary>
    /// Método que es llamado cuando no se mira a la esfera
    /// </summary>
    /// <remarks>
    /// Cambia el material de la esfera al correspondiente
    /// </remarks>
    public void NotHoveredSphere()
    {
        GetComponent<Renderer>().material = sphereMaterial;
    }

    #endregion
}
