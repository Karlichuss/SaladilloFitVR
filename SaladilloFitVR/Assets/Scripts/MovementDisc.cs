///////////////////////////////
// Práctica: SaladilloVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: MovementDisc.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDisc : MonoBehaviour {

    #region Declaracion de variables

    // Velocidad maxima de desplazamiento
    public float maxSpeed = 0.5f;
    // La fuerza de empuje
    public float pushForce = 10f;
    // Indica si el usuario esta mirando al disco directamente
    public bool isHover = false;
    // Referencia al rigidbody qe queremos mover
    public Rigidbody rigidbody;

    #endregion

    #region Metodos

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isHover)
        {
            if (rigidbody.velocity.magnitude < maxSpeed)
            {
                rigidbody.AddForce((GvrPointerInputModule.Pointer.CurrentRaycastResult.worldPosition - transform.position).normalized * pushForce);
            }
        }
	}

    /// <summary>
    /// Acciones a realizar para el evento de mirar el disco
    /// </summary>
    public void StartLookingAtDisc()
    {
        isHover = true;
    }

    /// <summary>
    /// Acciones a realizar para el evento de dejar de mirar el disco
    /// </summary>
    public void StopLookingAtDisc()
    {
        isHover = false;
    }

    #endregion

}
