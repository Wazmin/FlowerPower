using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour {
	
    //Panel pour griser une fois le vaisseau sélectionné
	public GameObject Panel1, Panel2, Panel3, Panel4;
    //int pour bouger d'un mesh a l'autre dans la fonction changemesh
	private int selectvalue1 = 1;
	private int selectvalue2 = 1;
	private int selectvalue3 = 1;
	private int selectvalue4 = 1;
	//bool vérifier que tel joueur a sélectionné son vaisseau et fixer selectvalue
	public bool V1selected = false;
	public bool V2selected = false;
	public bool V3selected = false;
	public bool V4selected = false;
    //bool vérifier que tel vaisseau à déjà été selectionné ou non
    public bool V1available = true, V2available = true, V3available = true, V4available = true;

    //les quatre vaisseaux des quatre joueurs
	public GameObject J1V1, J1V2, J1V3, J1V4;
	public GameObject J2V1, J2V2, J2V3, J2V4;
	public GameObject J3V1, J3V2, J3V3, J3V4;
	public GameObject J4V1, J4V2, J4V3, J4V4;
    //Cases des joueurs 2 3 et 4 pour les desactiver s'ils ne sont pas présents
	public GameObject CJ2, CJ3, CJ4;
    public GameObject B1, B2, B3, B4;
    public Sprite BoutonA, BoutonAbarré;
   //timer
	private float timer1, timer2, timer3, timer4;


	private GameObject Info;
	void Start () {
        //On récupère les infos de l'écran titre et on désactive les cases inutiles
		Info = GameObject.Find ("Info");
		deactivate ();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        //changer de vaisseau
        //J1
        if (V1selected == false)
        {
                if (Time.time - timer1 > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ1") > 0)
                    {
                        timer1 = Time.time;
                        selectvalue1++;
                        overvalue();
                        changemesh();
                    }
                }
                if (Time.time - timer1 > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ1") < 0)
                    {
                        timer1 = Time.time;
                        selectvalue1--;
                        overvalue();
                        changemesh();
                    }
                }
        }
        //J2
        if (V2selected == false)
        {

                if (Time.time - timer2 > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ2") > 0)
                    {
                        timer2 = Time.time;
                        selectvalue2++;
                        overvalue();
                        changemesh();
                    }
                }
                if (Time.time - timer2 > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ2") < 0)
                    {
                        timer2 = Time.time;
                        selectvalue2--;
                        overvalue();
                        changemesh();
                    }
                }
        }
        //J3
        if (V3selected == false)
        {
                if (Time.time - timer3 > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ3") > 0)
                    {
                        timer3 = Time.time;
                        selectvalue3++;
                        overvalue();
                        changemesh();
                    }
                }
                if (Time.time - timer3 > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ3") < 0)
                    {
                        timer3 = Time.time;
                        selectvalue3--;
                        overvalue();
                        changemesh();
                    }
            }
        }
        //J4
        if (V4selected == false)
        {
                if (Time.time - timer4 > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ4") > 0)
                    {
                        timer4 = Time.time;
                        selectvalue4++;
                        overvalue();
                        changemesh();
                    }
                }
                if (Time.time - timer4 > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ4") < 0)
                    {
                        timer4 = Time.time;
                        selectvalue4--;
                        overvalue();
                        changemesh();
                    }
            }
        }
        //choisir un vaisseau
        //J1
        if (Input.GetButtonDown("Boost_J1"))
        {
            if (Time.time - timer1 > 0.2f)
            {
                if ((selectvalue1 != Info.GetComponent<GetInfo>().vaisseauJ2) && (selectvalue1 != Info.GetComponent<GetInfo>().vaisseauJ3) &&  (selectvalue1 != Info.GetComponent<GetInfo>().vaisseauJ4))
                { 
                    if (V1selected == false)
                    {
                        V1selected = true;
                        if (selectvalue1 == 1)
                            V1available = false;
                        if (selectvalue1 == 2)
                            V2available = false;
                        if (selectvalue1 == 3)
                            V3available = false;
                        if (selectvalue1 == 4)
                            V4available = false;
                        timer1 = Time.time;
                        griser();
                        Info.GetComponent<GetInfo>().vaisseauJ1 = selectvalue1;
                        B1.SetActive(false);
                    }
                }
            }
        }
        //J2
        if (Input.GetButtonDown("Boost_J2"))
        {
            if (Time.time - timer2 > 0.2f)
            {
                if ((selectvalue2 != Info.GetComponent<GetInfo>().vaisseauJ1) && (selectvalue2 != Info.GetComponent<GetInfo>().vaisseauJ3) && (selectvalue1 != Info.GetComponent<GetInfo>().vaisseauJ4))
                {
                    if (V2selected == false)
                    {
                        V2selected = true;
                        if (selectvalue2 == 1)
                            V1available = false;
                        if (selectvalue2 == 2)
                            V2available = false;
                        if (selectvalue2 == 3)
                            V3available = false;
                        if (selectvalue2 == 4)
                            V4available = false;
                        timer2 = Time.time;
                        griser();
                        Info.GetComponent<GetInfo>().vaisseauJ2 = selectvalue2;
                        B2.SetActive(false);
                    }
                }
            }
        }
        //J3
        if (Input.GetButtonDown("Boost_J3"))
        {
            if (Time.time - timer3 > 0.2f)
            {
                if ((selectvalue3 != Info.GetComponent<GetInfo>().vaisseauJ1) && (selectvalue3 != Info.GetComponent<GetInfo>().vaisseauJ2) && (selectvalue3 != Info.GetComponent<GetInfo>().vaisseauJ4))
                {
                    if (V3selected == false)
                    {
                        V3selected = true;
                        if (selectvalue3 == 1)
                            V1available = false;
                        if (selectvalue3 == 2)
                            V2available = false;
                        if (selectvalue3 == 3)
                            V3available = false;
                        if (selectvalue3 == 4)
                            V4available = false;
                        timer3 = Time.time;
                        griser();
                        Info.GetComponent<GetInfo>().vaisseauJ3 = selectvalue3;
                        B3.SetActive(false);
                    }
                }
            }
        }
        //J4
        if (Input.GetButtonDown("Boost_J4"))
        {
            if (Time.time - timer4 > 0.2f)
            {
                if ((selectvalue4 != Info.GetComponent<GetInfo>().vaisseauJ1) && (selectvalue4 != Info.GetComponent<GetInfo>().vaisseauJ2) && (selectvalue4 != Info.GetComponent<GetInfo>().vaisseauJ3))
                {
                    if (V4selected == false)
                    {
                        V4selected = true;
                        if (selectvalue4 == 1)
                            V1available = false;
                        if (selectvalue4 == 2)
                            V2available = false;
                        if (selectvalue4 == 3)
                            V3available = false;
                        if (selectvalue4 == 4)
                            V4available = false;
                        timer4 = Time.time;
                        griser();
                        Info.GetComponent<GetInfo>().vaisseauJ4 = selectvalue4;
                        B4.SetActive(false);
                    }
                }
            }
        }
        //retour arrière.
        //J1
        if (Input.GetButtonDown("Action4_J1"))
            {
                if (V1selected == true)
                {
                    Panel1.SetActive(false);
                    V1selected = false;
                    B1.SetActive(true);
                    if (selectvalue1 == 1)
                        V1available = true;
                    if (selectvalue1 == 2)
                        V2available = true;
                    if (selectvalue1 == 3)
                        V3available = true;
                    if (selectvalue1 == 4)
                        V4available = true;
                }
                else
                {
                    Object.Destroy(GameObject.Find("Info"));
                    Object.Destroy(GameObject.Find("MusiqueEcranTitre"));
                    SceneManager.LoadScene("EcranTitre3");
                }
            }
        //J2
        if (Input.GetButtonDown("Action4_J2"))
        {
            if (V2selected == true)
            {
                Panel2.SetActive(false);
                V2selected = false;
                B2.SetActive(true);
                if (selectvalue2 == 1)
                    V1available = true;
                if (selectvalue2 == 2)
                    V2available = true;
                if (selectvalue2 == 3)
                    V3available = true;
                if (selectvalue2 == 4)
                    V4available = true;
            }
        }
        //J3
        if (Input.GetButtonDown("Action4_J3"))
        {
            if (V3selected == true)
            {
                Panel3.SetActive(false);
                V3selected = false;
                B3.SetActive(true);
                if (selectvalue3 == 1)
                    V1available = true;
                if (selectvalue3 == 2)
                    V2available = true;
                if (selectvalue3 == 3)
                    V3available = true;
                if (selectvalue3 == 4)
                    V4available = true;
            }
        }
        //J4
        if (Input.GetButtonDown("Action4_J4"))
        {
            if (V3selected == true)
            {
                Panel4.SetActive(false);
                V4selected = false;
                B4.SetActive(true);
                if (selectvalue4 == 1)
                    V1available = true;
                if (selectvalue4 == 2)
                    V2available = true;
                if (selectvalue4 == 3)
                    V3available = true;
                if (selectvalue4 == 4)
                    V4available = true;
            }
        }

    }

    void overvalue()
    {
        if (selectvalue1 > 4)
            selectvalue1 = 1;
        if (selectvalue1 < 1)
            selectvalue1 = 4;
        if (selectvalue2 > 4)
            selectvalue2 = 1;
        if (selectvalue2 < 1)
            selectvalue2 = 4;
        if (selectvalue3 > 4)
            selectvalue3 = 1;
        if (selectvalue3 < 1)
            selectvalue3 = 4;
        if (selectvalue4 > 4)
            selectvalue4 = 1;
        if (selectvalue4 < 1)
            selectvalue4 = 4;
    }
    //griser la case d'un joueur une fois son vaisseau sélectionné
    void griser(){
		if (V1selected == true)
			Panel1.SetActive (true);
		if (V2selected == true)
			Panel2.SetActive (true);
		if (V3selected == true)
			Panel3.SetActive (true);
		if (V4selected == true)
			Panel4.SetActive (true);
	}

	void changemesh (){
        //changement de l'image du vaisseau
		//J1

		if (selectvalue1 == 1){
			J1V1.gameObject.SetActive(true);
			J1V2.gameObject.SetActive (false);
			J1V3.gameObject.SetActive (false);
			J1V4.gameObject.SetActive (false);
		}
		if (selectvalue1 == 2){
			J1V1.gameObject.SetActive (false);
			J1V2.gameObject.SetActive (true);
			J1V3.gameObject.SetActive (false);
			J1V4.gameObject.SetActive (false);	
		}
		if (selectvalue1 == 3){
			J1V1.gameObject.SetActive (false);
			J1V2.gameObject.SetActive (false);
			J1V3.gameObject.SetActive (true);
			J1V4.gameObject.SetActive (false);
		}
		if (selectvalue1 == 4){
			J1V1.gameObject.SetActive (false);
			J1V2.gameObject.SetActive (false);
			J1V3.gameObject.SetActive (false);
			J1V4.gameObject.SetActive (true);
		}
        //J2
        if (CJ2.activeInHierarchy == true) { 
            if (selectvalue2== 1)
            {
                J2V1.gameObject.SetActive(true);
                J2V2.gameObject.SetActive(false);
                J2V3.gameObject.SetActive(false);
                J2V4.gameObject.SetActive(false);
            }
            if (selectvalue2 == 2)
            {
                J2V1.gameObject.SetActive(false);
                J2V2.gameObject.SetActive(true);
                J2V3.gameObject.SetActive(false);
                J2V4.gameObject.SetActive(false);
            }
            if (selectvalue2 == 3)
            {
                J2V1.gameObject.SetActive(false);
                J2V2.gameObject.SetActive(false);
                J2V3.gameObject.SetActive(true);
                J2V4.gameObject.SetActive(false);
            }
            if (selectvalue2 == 4)
            {
                J2V1.gameObject.SetActive(false);
                J2V2.gameObject.SetActive(false);
                J2V3.gameObject.SetActive(false);
                J2V4.gameObject.SetActive(true);
            }
        }
        //J3
        if (CJ3.activeInHierarchy == true)
        {
            if (selectvalue3 == 1)
            {
                J3V1.gameObject.SetActive(true);
                J3V2.gameObject.SetActive(false);
                J3V3.gameObject.SetActive(false);
                J3V4.gameObject.SetActive(false);
            }
            if (selectvalue3 == 2)
            {
                J3V1.gameObject.SetActive(false);
                J3V2.gameObject.SetActive(true);
                J3V3.gameObject.SetActive(false);
                J3V4.gameObject.SetActive(false);
            }
            if (selectvalue3 == 3)
            {
                J3V1.gameObject.SetActive(false);
                J3V2.gameObject.SetActive(false);
                J3V3.gameObject.SetActive(true);
                J3V4.gameObject.SetActive(false);
            }
            if (selectvalue3 == 4)
            {
                J3V1.gameObject.SetActive(false);
                J3V2.gameObject.SetActive(false);
                J3V3.gameObject.SetActive(false);
                J3V4.gameObject.SetActive(true);
            }
        }
        //J4
        if (CJ4.activeInHierarchy == true)
        {
            if (selectvalue4 == 1)
            {
                J4V1.gameObject.SetActive(true);
                J4V2.gameObject.SetActive(false);
                J4V3.gameObject.SetActive(false);
                J4V4.gameObject.SetActive(false);
            }
            if (selectvalue4 == 2)
            {
                J4V1.gameObject.SetActive(false);
                J4V2.gameObject.SetActive(true);
                J4V3.gameObject.SetActive(false);
                J4V4.gameObject.SetActive(false);
            }
            if (selectvalue4 == 3)
            {
                J4V1.gameObject.SetActive(false);
                J4V2.gameObject.SetActive(false);
                J4V3.gameObject.SetActive(true);
                J4V4.gameObject.SetActive(false);
            }
            if (selectvalue4 == 4)
            {
                J4V1.gameObject.SetActive(false);
                J4V2.gameObject.SetActive(false);
                J4V3.gameObject.SetActive(false);
                J4V4.gameObject.SetActive(true);
            }
        }
        UnavailableShips();
    }



//interrupteur pour éviter que deactivate tourne en boucle. Je sais pas s'il est encore nécessaire, je crois que non

private bool interrupteur = true;

    void deactivate(){
	if(interrupteur == true){
		interrupteur = false;
		if (Info.GetComponent<GetInfo> ().NbJoueur == 3){
			CJ4.SetActive (false);
		}
		else if (Info.GetComponent<GetInfo> ().NbJoueur == 2) {
			CJ3.SetActive (false);
			CJ4.SetActive (false);
		}
		else if (Info.GetComponent<GetInfo> ().NbJoueur == 1) {
			CJ2.SetActive (false);
			CJ3.SetActive (false);
			CJ4.SetActive (false);
		}
	}
	}

    void UnavailableShips()
    {
        //J1
        if (selectvalue1 == 1)
        {
            if (V1available == false)
            {
                B1.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
            }
            else
            {
                B1.GetComponent<SpriteRenderer>().sprite = BoutonA;
            }
        }
        if (selectvalue1 == 2)
        {
            if (V2available == false)
            {
                B1.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
            }
            else
            {
                B1.GetComponent<SpriteRenderer>().sprite = BoutonA;
            }
        }
        if (selectvalue1 == 3)
        {
            if (V3available == false)
            {
                B1.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
            }
            else
            {
                B1.GetComponent<SpriteRenderer>().sprite = BoutonA;
            }
        }
        if (selectvalue1 == 4)
        {
            if (V4available == false)
            {
                B1.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
            }
            else
            {
                B1.GetComponent<SpriteRenderer>().sprite = BoutonA;
            }
        }

        //J2
        if (Info.GetComponent<GetInfo>().NbJoueur > 1)
        {
            if (selectvalue2 == 1)
            {
                if (V1available == false)
                {
                    B2.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
                }
                else
                {
                    B2.GetComponent<SpriteRenderer>().sprite = BoutonA;
                }
            }
            if (selectvalue2 == 2)
            {
                if (V2available == false)
                {
                    B2.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
                }
                else
                {
                    B2.GetComponent<SpriteRenderer>().sprite = BoutonA;
                }
            }
            if (selectvalue2 == 3)
            {
                if (V3available == false)
                {
                    B2.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
                }
                else
                {
                    B2.GetComponent<SpriteRenderer>().sprite = BoutonA;
                }
            }
            if (selectvalue2 == 4)
            {
                if (V4available == false)
                {
                    B2.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
                }
                else
                {
                    B2.GetComponent<SpriteRenderer>().sprite = BoutonA;
                }
            }
        }

        //J3
        if (Info.GetComponent<GetInfo>().NbJoueur > 1)
        {
            if (selectvalue3 == 1)
            {
                if (V1available == false)
                {
                    B3.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
                }
                else
                {
                    B3.GetComponent<SpriteRenderer>().sprite = BoutonA;
                }
            }
            if (selectvalue3 == 2)
            {
                if (V2available == false)
                {
                    B3.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
                }
                else
                {
                    B3.GetComponent<SpriteRenderer>().sprite = BoutonA;
                }
            }
            if (selectvalue3 == 3)
            {
                if (V3available == false)
                {
                    B3.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
                }
                else
                {
                    B3.GetComponent<SpriteRenderer>().sprite = BoutonA;
                }
            }
            if (selectvalue3 == 4)
            {
                if (V4available == false)
                {
                    B3.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
                }
                else
                {
                    B3.GetComponent<SpriteRenderer>().sprite = BoutonA;
                }
            }
        }

        //J4
        if (Info.GetComponent<GetInfo>().NbJoueur > 3)
        {
            if (selectvalue4 == 1)
            {
                if (V1available == false)
                {
                    B4.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
                }
                else
                {
                    B4.GetComponent<SpriteRenderer>().sprite = BoutonA;
                }
            }
            if (selectvalue4 == 2)
            {
                if (V2available == false)
                {
                    B4.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
                }
                else
                {
                    B4.GetComponent<SpriteRenderer>().sprite = BoutonA;
                }
            }
            if (selectvalue4 == 3)
            {
                if (V3available == false)
                {
                    B4.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
                }
                else
                {
                    B4.GetComponent<SpriteRenderer>().sprite = BoutonA;
                }
            }
            if (selectvalue4 == 4)
            {
                if (V4available == false)
                {
                    B4.GetComponent<SpriteRenderer>().sprite = BoutonAbarré;
                }
                else
                {
                    B4.GetComponent<SpriteRenderer>().sprite = BoutonA;
                }
            }
        }
    }
}
