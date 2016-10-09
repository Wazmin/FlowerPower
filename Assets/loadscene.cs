using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    public GameObject projectile;
    void Update()
    {
        if (Input.GetButtonDown("Boost_J1"))
            SceneManager.LoadScene("principale");
    }
}