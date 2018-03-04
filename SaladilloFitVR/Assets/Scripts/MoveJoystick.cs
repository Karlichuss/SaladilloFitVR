///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: MoveJoystick.cs
///////////////////////////////

using UnityEngine;

public class MoveJoystick : MonoBehaviour
{

    #region Declaración de variables

    // Velocidad máxima de desplazamiento
    public float maxSpeed = 0.5f;
    // La fuerza de empuje
    public float pushForce = 10f;
    // Referencia al rigidbody que queremos mover
    public Rigidbody rigidbody;

    #endregion

    #region Métodos

    // Use this for initialization
    void Awake()
    {
        // Recuperamos la referencia al componente Rigidbody
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Recuperamos el valor de los ejes horizontal y vertical
        // Son valores normalizados que van de 0 a 1
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Calculamos el vector de movimiento con la dirección a la que mira la cámara
        Vector3 moveDirection = (h * Camera.main.transform.right + v * Camera.main.transform.forward).normalized;

        // Comprobamos la magnitud de desplazamiento y aplicamos el empuje si la velocidad máxima no se ha alcanzado
        if (rigidbody.velocity.magnitude < maxSpeed)
        {
            // Aplicamos el empuje en la dirección calculada con la fuerza indicada
            rigidbody.AddForce(moveDirection * pushForce);
        }
    }

    #endregion

}
