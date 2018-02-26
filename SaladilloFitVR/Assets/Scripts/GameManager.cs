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

    // Constante con la URL del metodo de la Web API para comprobar la conectividad
    public const string WEB_API_CHECK_CONECTIVITY = "http://{0}/SaladilloVR/api/SaladilloVR/CheckConnectivity";

    // Constante con la URL de la WEb API que contiene una lista de clientes
    public const string WEB_API_GET_CLIENTS = "http://{0}/SaladilloVR/api/SaladilloVR/GetClients";

    // Constante con la URL de la WEb API que guarda la informacion de un cliente
    public const string WEB_API_LOG_CLIENT = "http://{0}/SaladilloVR/api/SaladilloVR/LogClient";
}