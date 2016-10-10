using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class loadscene : MonoBehaviour
{
    public  UnityEngine.AudioSource vroum;
public AudioClip ready;

    
    void Update()
    {
        if (Input.GetButtonDown("Boost_J1")) {
        vroum.PlayOneShot(ready, 2.0f);
            SceneManager.LoadScene("principale");
        
    }

}
}