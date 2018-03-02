///////////////////////////////
// Práctica: SaladilloVR
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: GameManager.cs
///////////////////////////////

public static class GameManager {

    // Clave para la direccion IP
    public const string IP_ADDRESS = "IP_ADDRESS";

    // Variable para almacenar la direccion IP de la Web API
    public static string ipAddress;

    public static string localhost = "localhost:49446";

    // Constante con la URL del metodo de la Web API para comprobar la conectividad
    public const string WEB_API_CHECK_CONECTIVITY = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/CheckConnectivity";
    public const string WEB_API_CHECK_CONECTIVITY_LOCAL = "http://{0}/api/SaladilloFitVR/CheckConnectivity";


    // Constante con la URL de la WEb API que contiene una lista de clientes
    public const string WEB_API_GET_CLIENT = "http://{0}/api/SaladilloFitVR/GetClientName";

    // Constante con la URL de la WEb API que guarda la informacion de un cliente
    public const string WEB_API_LOG_CLIENT = "http://{0}/api/SaladilloFitVR/GetClientName?dni={1}";

    // Constante con la URL de la WEb API que contiene una lista de clientes
    public const string WEB_API_GET_TRAINING = "http://{0}/SaladilloFitVR/api/SaladilloFitVR/GetTraining";
    public const string WEB_API_GET_TRAINING_LOCAL = "http://{0}/api/SaladilloFitVR/GetTrainingList?training={1}";
}