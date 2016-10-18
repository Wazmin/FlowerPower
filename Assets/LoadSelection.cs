using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSelection: MonoBehaviour
{
	private GameObject CJ2, CJ3, CJ4;
	private GameObject Info;
	public  UnityEngine.AudioSource vroum;
	public AudioClip ready;
	public AudioClip bipChangementJoueur;
	public AudioClip bipchangementMap;
	public string Map = "Canyon";
	public Text nbJoueur;
	public Text NomMap;
    public Text NombreDeTour;
	public int nombreJoueur = 4;
    public int NombreTour = 3;

    public int selecteur = 3;

	private float timer;

	void Start()
	{
        selectposition();
		timer = Time.time;
	}

	void Update()
	{
		if (Input.GetButtonDown("Boost_J1"))
		{
				vroum.PlayOneShot(ready, 2.0f);
				SceneManager.LoadScene("SelectionVaisseauTest");
			}

        if (Input.GetAxis("downNbJoueur") > 0)
        {
            if (Time.time - timer > 0.2f)
            {
                timer = Time.time;
                selecteur++;
                vroum.PlayOneShot(bipchangementMap);
                OvervalueSelect();
                selectposition();
            }
        }
        if (Input.GetAxis("downNbJoueur") < 0)
        {
            if (Time.time - timer > 0.2f)
            {
                timer = Time.time;
                selecteur--;
                vroum.PlayOneShot(bipchangementMap);
                OvervalueSelect();
                selectposition();
            }
        }

        if (selecteur == 3)
        {
            if (Input.GetAxis("leftMapSelect") > 0)
            {
                if (Time.time - timer > 0.4f)
                {
                    timer = Time.time;
                    if (++nombreJoueur > 4) nombreJoueur = 4;
                    nbJoueur.text = setTextJoueur();
                    vroum.PlayOneShot(bipChangementJoueur);
                }

            }
            else if (Input.GetAxis("leftMapSelect") < 0)
            {
                if (Time.time - timer > 0.4f)
                {
                    timer = Time.time;
                    if (--nombreJoueur < 1) nombreJoueur = 1;
                    nbJoueur.text = setTextJoueur();
                    vroum.PlayOneShot(bipChangementJoueur);
                }
            }
        }


        if (selecteur == 2) { 
		    if (Input.GetAxis("leftMapSelect")>0)
		    {
			    if(Time.time - timer > 0.2f)
			    {
				    timer = Time.time;
				    if (Map=="Canyon"){
					    Map = "RCanyon";
					    vroum.PlayOneShot(bipChangementJoueur);
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
					    vroum.PlayOneShot(bipChangementJoueur);
					    NomMap.text= Map;
				    }

			    }

		    }
        }
        if (selecteur == 1)
        {
            if (Input.GetAxis("leftMapSelect") > 0)
            {
                if (Time.time - timer > 0.2f)
                {
                    timer = Time.time;
                    NombreTour++;
                    vroum.PlayOneShot(bipChangementJoueur);
                    NombreDeTour.text = NombreTour.ToString();
                    OvervalueTour ();
                    }

                }

            if (Input.GetAxis("leftMapSelect") < 0)
            {
                if (Time.time - timer > 0.2f)
                {
                    timer = Time.time;
                    NombreTour--;
                    vroum.PlayOneShot(bipChangementJoueur);
                    NombreDeTour.text = NombreTour.ToString();
                    OvervalueTour();

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

    void selectposition ()
    {
        if (selecteur == 1)
        {
            nbJoueur.color = Color.grey;
            NomMap.color = Color.grey;
            NombreDeTour.color = Color.white;
        }
        if (selecteur == 2)
        {
            nbJoueur.color = Color.grey;
            NomMap.color = Color.white;
            NombreDeTour.color = Color.grey;
        }
        if (selecteur == 3)
        {
            nbJoueur.color = Color.white;
            NomMap.color = Color.grey;
            NombreDeTour.color = Color.grey;
        }
    }

    void OvervalueTour()
    {
        if (NombreTour > 9)
            NombreTour = 1;
        NombreDeTour.text = NombreTour.ToString();
        if (NombreTour < 1)
            NombreTour = 9;
        NombreDeTour.text = NombreTour.ToString();
    }
    void OvervalueSelect()
    {
        if (selecteur > 3)
            selecteur = 1;
        if (selecteur < 1)
            selecteur = 3;
    }
}