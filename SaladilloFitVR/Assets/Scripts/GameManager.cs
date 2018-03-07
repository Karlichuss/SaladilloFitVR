///////////////////////////////
// Práctica: SaladilloFitVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: GameManager.cs
///////////////////////////////

public static class GameManager
{

    // Clave para la direccion IP
    public const string IP_ADDRESS = "IP_ADDRESS";

    // Variable para almacenar la dirección IP de la WebAPI
    public static string ipAddress;

    // Variable para almacenar el DNI del usuario
    public static string dni;

    // Variable para almacenar el nombre del usuario
    public static string name;

    // Variable para almacenar el entrenamiento seleccionado
    public static int training;

    // Constante con la URL de la WebAPI que comprueba la conectividad
    public const string WEB_API_CHECK_CONECTIVITY = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/CheckConnectivity";

    // Constante con la URL de la WebAPI que contiene una lista de clientes
    public const string WEB_API_GET_CLIENT = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetClientName?dni={1}";

    // Constante con la URL de la WebAPI que guarda la información de un cliente
    public const string WEB_API_LOG_TRAINING = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/LogTraining";

    // Constante con la URL de la WebAPI que contiene una lista de ejercicios
    public const string WEB_API_GET_TRAINING = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetTraining?training={1}";

    // Constante con la URL de la WebAPI que obtiene los ultimos 3 entrenamientos de un cliente
    public const string WEB_API_GET_HISTORY = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetHistory?dni={1}";

    // Constante con la URL de la WebAPI que guarda la información de un cliente
    public const string WEB_API_END_TRAINING = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/EndTraining";

}