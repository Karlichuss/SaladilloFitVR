///////////////////////////////
// Práctica: SaladilloVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: PlayAnimation.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{

    #region Declaracion de variables

    // El tiempo que ha de pasar para que el temporizador se acabe
    public float activationTime = 3f;
    // Controla que se esta mirando fijamente
    private bool isHover = false;
    // Controla que la accion se haya ejecutado
    private bool executed = false;
    // La referencia al jugador
    public GameObject player;

    #endregion
    
    #region Metodos
    
    // Update is called once per frame
    void Update()
    {
        // Si el usuario esta mirando el objeto y el temporizador
        // ha terminado de contrar o si el usuario esta mirando el 
        // objeto y pulsa el boton fire1 del mando y la accion aun
        // no se ha ejecutado, realizaremos la accion correspondiente
        if ((isHover && CustomPointerTimer.CPT.ended && !executed) ||
            (isHover && Input.GetButtonDown("Fire1") && !executed))
        {
            // Se indicaa que se ha realizado la accion
            executed = true;
            // Desactivaremos el contadoe de tiempo del cursor, para
            // evitar que se quede bloqueado
            CustomPointerTimer.CPT.StopCounting();
            // Se lanza la animacion
            player.GetComponent<Animator>().Play("ScrollDown");
        }
    }

    /// <summary>
    /// Metodo que llamaremos desde el EventTrigger PointerEnter
    /// </summary>
    public void StartHover()
    {
        // Indicamos que el objeto esta siendo mirado directamente
        isHover = true;
        // Marcamos la accion como no realizada
        executed = false;
        // Iniciamos el contador del puntero, indicandole el tiempo de activacion
        CustomPointerTimer.CPT.StartCounting(activationTime);
    }

    /// <summary>
    /// Metodo que llamaremos desde el EventTrigger PointerExit
    /// </summary>
    public void EndHover()
    {
        // Indicamos que el objeto ya no esta siendo mirado
        isHover = false;
        // Reiniciamos el contador del puntero
        CustomPointerTimer.CPT.StopCounting();
    }

    #endregion

}
