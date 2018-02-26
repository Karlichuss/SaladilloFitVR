///////////////////////////////
// Práctica: SaladilloVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: ScrollDown.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour {

    #region Metodos

    // Use this for initialization
    void Start () {
        GetComponent<Animator>().Play("ScrollDown");
	}

    #endregion

}
