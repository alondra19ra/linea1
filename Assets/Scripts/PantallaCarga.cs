using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaCarga : MonoBehaviour
{
    void Start()
    {
        Invoke("IrALogin", 5f); 
    }

    void IrALogin()
    {
        SceneManager.LoadScene("Login");
    }
}