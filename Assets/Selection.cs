using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {
	

	public GameObject Panel1, Panel2, Panel3, Panel4;

	private int selectvalue1 = 1;
	private int selectvalue2 = 1;
	private int selectvalue3 = 1;
	private int selectvalue4 = 1;
	private int indexjoueur;
	public bool V1selected = false;
	public bool V2selected = false;
	public bool V3selected = false;
	public bool V4selected = false;

	public GameObject J1V1, J1V2, J1V3, J1V4;
	public GameObject J2V1, J2V2, J2V3, J2V4;
	public GameObject J3V1, J3V2, J3V3, J3V4;
	public GameObject J4V1, J4V2, J4V3, J4V4;

	public GameObject CJ2, CJ3, CJ4;
   


	private float timer;


	private GameObject Info;
	void Start () {
		Info = GameObject.Find ("Info");
		deactivate ();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        //changer de vaisseau
        if (V1selected == false)
        {
                if (Time.time - timer > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ1") > 0)
                    {
                        timer = Time.time;
                        selectvalue1++;
                        overvalue();
                        changemesh();
                    }
                }
                if (Time.time - timer > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ1") < 0)
                    {
                        timer = Time.time;
                        selectvalue1--;
                        overvalue();
                        changemesh();
                    }
                }
        }
        if (V2selected == false)
        {

                if (Time.time - timer > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ2") > 0)
                    {
                        timer = Time.time;
                        selectvalue2++;
                        overvalue();
                        changemesh();
                    }
                }
                if (Time.time - timer > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ2") < 0)
                    {
                        timer = Time.time;
                        selectvalue2--;
                        overvalue();
                        changemesh();
                    }
                }
        }
        if (V3selected == false)
        {
                if (Time.time - timer > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ3") > 0)
                    {
                        timer = Time.time;
                        selectvalue3++;
                        overvalue();
                        changemesh();
                    }
                }
                if (Time.time - timer > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ3") < 0)
                    {
                        timer = Time.time;
                        selectvalue3--;
                        overvalue();
                        changemesh();
                    }
            }
        }
        if (V4selected == false)
        {
                if (Time.time - timer > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ4") > 0)
                    {
                        timer = Time.time;
                        selectvalue4++;
                        overvalue();
                        changemesh();
                    }
                }
                if (Time.time - timer > 0.4f)
                {
                    if (Input.GetAxis("HorizontalJ4") < 0)
                    {
                        timer = Time.time;
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
            if (Time.time - timer > 0.2f)
            {
                if (V1selected == false)
                {
                    V1selected = true;
                    timer = Time.time;
                    griser();
                    Info.GetComponent<GetInfo>().vaisseauJ1 = selectvalue1;
                }
            }
        }
        //J2
        if (Input.GetButtonDown("Boost_J2"))
        {
            if (Time.time - timer > 0.2f)
            {
                if (V2selected == false)
                {
                    V2selected = true;
                    timer = Time.time;
                    griser();
                    Info.GetComponent<GetInfo>().vaisseauJ2 = selectvalue2;
                }
            }
        }
        //J3
        if (Input.GetButtonDown("Boost_J3"))
        {
            if (Time.time - timer > 0.2f)
            {
                if (V3selected == false)
                {
                    V3selected = true;
                    timer = Time.time;
                    griser();
                    Info.GetComponent<GetInfo>().vaisseauJ3 = selectvalue3;
                }
            }
        }
        //J4
        if (Input.GetButtonDown("Boost_J4"))
        {
            if (Time.time - timer > 0.2f)
            {
                if (V4selected == false)
                {
                    V4selected = true;
                    timer = Time.time;
                    griser();
                    Info.GetComponent<GetInfo>().vaisseauJ4 = selectvalue4;
                }
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
    }




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
}
