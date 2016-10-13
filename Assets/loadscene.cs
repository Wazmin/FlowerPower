using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class loadscene : MonoBehaviour
{
    public  UnityEngine.AudioSource vroum;
    public AudioClip ready;
    public AudioClip bipChangementJoueur;
	public AudioClip bipchangementMap;
	private string Map = "Canyon";
    public Text nbJoueur;
	public Text NomMap;
	public int nombreJoueur = 4;

    private float timer;

    void Start()
    {
        timer = Time.time;
    }
    
    void Update()
    {
		if (Input.GetButtonDown("Boost_J1"))
		{
			if (Map == "Canyon"){
				vroum.PlayOneShot(ready, 2.0f);
				SceneManager.LoadScene("principale"+nombreJoueur.ToString()+"J");
			}			
			if (Map == "RCanyon"){
				vroum.PlayOneShot(ready, 2.0f);
				SceneManager.LoadScene("Reverse"+nombreJoueur.ToString()+"J");
			}
        }

        if (Input.GetAxis("upNbJoueur")>0)
        {
            if(Time.time - timer > 0.2f)
            {
                timer = Time.time;
                if (++nombreJoueur > 4) nombreJoueur = 4;
                nbJoueur.text = setTextJoueur();
                vroum.PlayOneShot(bipChangementJoueur);
            }
            
        }
        else if (Input.GetAxis("upNbJoueur") < 0)
        {
            if (Time.time - timer > 0.2f)
            {
                timer = Time.time;
                if (--nombreJoueur < 1) nombreJoueur = 1;
                nbJoueur.text = setTextJoueur();
                vroum.PlayOneShot(bipChangementJoueur);
            }
            
		}        
		if (Input.GetAxis("leftMapSelect")>0)
		{
			if(Time.time - timer > 0.2f)
			{
				timer = Time.time;
				if (Map=="Canyon"){
				Map = "RCanyon";
				vroum.PlayOneShot(bipchangementMap);
				NomMap.text= Map;
			}

				}

		}
		if (Input.GetAxis("leftMapSelect")<0)
		{
			if(Time.time - timer > 0.2f)
			{
				timer = Time.time;
				if (Map=="RCanyon"){
					Map = "Canyon";
					vroum.PlayOneShot(bipchangementMap);
					NomMap.text= Map;
				}

			}

		}
    }

    private string setTextJoueur()
    {
        if (nombreJoueur <= 1)
        {
            return (nombreJoueur.ToString() + " joueur");
        }
        else
        {
            return (nombreJoueur.ToString() + " joueurs");
        }
    }


}