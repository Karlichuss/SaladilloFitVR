///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: ButtonGazeClick.cs
///////////////////////////////

using UnityEngine;
using UnityEngine.UI;

public class ButtonGazeClick : MonoBehaviour
{

    #region Declaración de variables

    // Tiempo que tardará en activarse el temporizador
    public float activationTime = 3f;
    // Indica si el puntero esta sobre el objeto
    private bool isHover = false;
    // Indica si la acción se ha realizado
    private bool executed = false;

    #endregion

    #region Métodos

    // Update is called once per frame
    void Update()
    {
        // Si el usuario esta mirando el objeto y el temporizador
        // ha terminado de contar, o si el usuario esta mirando el 
        // objeto y pulsa el botón "Fire1" del mando y la acción aún
        // no se ha ejecutado, realizaremos la acción correspondiente
        if ((isHover && CustomPointerTimer.CPT.ended && !executed) ||
            (isHover && Input.GetButtonDown("Fire1") && !executed))
        {
            // Se indica que se ha realizado la acción
            executed = true;
            // Desactivaremos el contador de tiempo del cursor, para
            // evitar que se quede bloqueado
            CustomPointerTimer.CPT.StopCounting();
            // Se invoca el click del botón
            GetComponent<Button>().onClick.Invoke();
        }
    }


    /// <summary>
    /// Método que llamaremos desde el EventTrigger PointerEnter.
    /// </summary>
    public void StartHover()
    {
        // Indicamos que el objeto esta siendo mirado directamente
        isHover = true;
        // Marcamos la acción como no realizada
        executed = false;
        // Iniciamos el contador del puntero, indicandole el tiempo de activación
        CustomPointerTimer.CPT.StartCounting(activationTime);
    }

    /// <summary>
    /// Método que llamaremos desde el EventTrigger PointerExit.
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
