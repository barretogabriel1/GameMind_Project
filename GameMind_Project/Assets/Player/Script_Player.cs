using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_Player : MonoBehaviour
{
    private Animator myAnimator;
	public float velGiro = 200f;

	public int boxPoints = 0;
	public int cylinderPoints = 0;
	public int spherePoints = 0;

	public Text boxText;
	public Text sphereText;
	public Text cylinderText;
	public Text error;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        myAnimator.SetFloat("Speed", Input.GetAxis("Vertical"));

        transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal") * velGiro * Time.deltaTime,0));
       
        if(Input.GetButtonDown("Jump")) {
        	myAnimator.SetBool("Jumping", true);
        	Invoke("StopJump", 0.1f);
        }

        //Condição de vitória
        if (boxPoints >= 5 && cylinderPoints >= 5 && spherePoints >= 5) {
        	SceneManager.LoadScene("Win");
        }
    }

    void StopJump() {
    	myAnimator.SetBool("Jumping", false);
    }


    //Detectar que coletou um objeto
    void OnTriggerEnter(Collider colisor) {

    	//Objetos corretos
		if(colisor.gameObject.tag == "Box") {
			colisor.gameObject.SetActive(false);
			boxPoints += 1;
            boxText.text = boxPoints.ToString();
		}
		else if(colisor.gameObject.tag == "Sphere") {
			colisor.gameObject.SetActive(false);
			spherePoints += 1;
            sphereText.text = spherePoints.ToString();
		}
		else if(colisor.gameObject.tag == "Cylinder") {
			colisor.gameObject.SetActive(false);
			cylinderPoints += 1;
            cylinderText.text = cylinderPoints.ToString();
		}

		//Armadilhas
		if(colisor.gameObject.tag == "Blue") {
			colisor.gameObject.SetActive(false);
			error.gameObject.SetActive(true);
			Invoke("desativarError", 3f);
			boxPoints -= 1;
            boxText.text = boxPoints.ToString();
		}
		else if(colisor.gameObject.tag == "Green") {
			colisor.gameObject.SetActive(false);
			error.gameObject.SetActive(true);
			Invoke("desativarError", 3f);
			spherePoints -= 1;
            sphereText.text = spherePoints.ToString();
		}
		else if(colisor.gameObject.tag == "Red") {
			colisor.gameObject.SetActive(false);
			error.gameObject.SetActive(true);
			Invoke("desativarError", 3f);
			cylinderPoints -= 1;
            cylinderText.text = cylinderPoints.ToString();
		}
	}

	void desativarError() {
		error.gameObject.SetActive(false);
	}

}
