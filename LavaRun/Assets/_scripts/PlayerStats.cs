using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	int totalNumExercises;
	public GameObject lava;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//shift lava forwards
	public void shiftLavaUp(){
		lava.transform.position += Vector3.left * 40f; 
	}
	//shift lava backwards
	//Jog in place(raise hr)
	//water break(lower hr)
	//choose exercise
	//exercise prompt
	//exercises 1-whatever
}


