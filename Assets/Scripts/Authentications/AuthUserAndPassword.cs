using System;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AuthUserAndPassword : MonoBehaviour
{
    [SerializeField] private TMP_InputField userName;
    [SerializeField] private TMP_InputField passWord;
    [SerializeField] private GameObject textLogin;
    [SerializeField] private GameObject textRecord;

    private bool servicesInitialized = false;

    private async void Awake()
    {
        await InitializeServices();
    }

    private async System.Threading.Tasks.Task InitializeServices()
    {
        if (servicesInitialized) return;

        try
        {
            await UnityServices.InitializeAsync();
            servicesInitialized = true;

            Debug.Log("Servicios inicializados correctamente");
        }
        catch (Exception e)
        {
            Debug.LogError($"Error al inicializar servicios: {e}");
        }
    }

    // REGISTRAR USUARIO
    public async void Register()
    {
        if (!servicesInitialized)
        {
            Debug.LogWarning("Servicios no inicializados aún");
            return;
        }

        textRecord.SetActive(false);

        try
        {
            await AuthenticationService.Instance
                .SignUpWithUsernamePasswordAsync(userName.text, passWord.text);

            Debug.Log("Registro exitoso");
            IrAlInicio();
        }
        catch (Exception e)
        {
            Debug.LogWarning($"Error en registro: {e}");
            textRecord.SetActive(true);
        }
    }

    // INICIAR SESIÓN
    public async void Insert()
    {
        if (!servicesInitialized)
        {
            Debug.LogWarning("Servicios no inicializados aún");
            return;
        }

        textLogin.SetActive(false);

        try
        {
            await AuthenticationService.Instance
                .SignInWithUsernamePasswordAsync(userName.text, passWord.text);

            Debug.Log("Login exitoso");
            IrAlInicio();
        }
        catch (Exception e)
        {
            Debug.LogWarning($"Error en login: {e}");
            textLogin.SetActive(true);
        }
    }

    // CAMBIO DE ESCENA
    private void IrAlInicio()
    {
        SceneManager.LoadScene("Inicio");
    }
}