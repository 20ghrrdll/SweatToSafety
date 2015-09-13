using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	int totalNumExercises;
	public GameObject lava;
	public GameObject player;
	public GameObject InfoPanel;
	public Text PlayerPrompt;
	struct Exercise{
		public string name;
		public int timesSeen;
	};
	Exercise[] Activities;
	int level = 0;
	int[] numActivitiesToComplete = {6, 8, 10};
	Stopwatch timer = null;
	int counter = 0;
	Vector3 scaleIterator;

	// Use this for initialization
	void Start () {
		string[] exerciseNames = {
			"Jumping Jacks",
			"Crunches",
			"Push-ups",
			"Squats",
			"Lunges",
			"Lunge Jumps",
			"Leg Lifts",
			"Bicycle Crunches"
		};
		PlayerPrompt = InfoPanel.GetComponent<Text> ();
		Activities = new Exercise[8];
		for (int a = 0; a < 8; a ++) {
			Activities [a].name = exerciseNames [a];
			Activities[a].timesSeen = 0;
		}
		timer = new Stopwatch ();
		scaleIterator = new Vector3(1f,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		while (counter < 100) {
			player.transform.localScale += scaleIterator;
			counter++;
		}
		while (counter >=100 && counter < 200){
			player.transform.localScale -=scaleIterator;
			counter++;
		}
		if (counter >= 200)
			counter = 0;
	
	}
	//Set level of exercise intensity
	public void setLevel(int levelChoice){
		level = levelChoice;
	}
	//shift lava forwards
	public void shiftLavaUp(){
		lava.transform.localPosition += Vector3.left * 40f; 
	}
	//shift lava backwards
	public void shiftLavaDown(){
		lava.transform.localPosition += Vector3.right * 40f;
	}
	//Jog in place(raise hr)
	public void jogInPlace(){
		InfoPanelPopUp("Jog in place! The lava's coming!");
	}
	//water break(lower hr)
	public void waterBreak(){
		timer.Reset();
		InfoPanelPopUp("Take a water break! You deserve it!");
		timer.Start();
		bool onBreak = true;
		TimeSpan stopTime = new TimeSpan (0, 2, 0);
		while (onBreak) {
			if(timer.Elapsed >= stopTime){
				onBreak = false;
			}
		}
		timer.Stop ();
		jogInPlace ();
	}
	//choose exercise
	public void chooseExercise(){
		int exerciseNum = (int)(UnityEngine.Random.Range (0f, 8f));

		while (Activities[exerciseNum].timesSeen > 2) {
			exerciseNum = (int)(UnityEngine.Random.Range(0f, 8f));
		}
		Activities [exerciseNum].timesSeen++;
		int reps = (int)(UnityEngine.Random.Range (7f, 20f));
		string prompt = "Do " + reps + " " + Activities [exerciseNum].name+"!";
		InfoPanelPopUp (prompt);
	}

	//exercise prompt
	public void InfoPanelPopUp(string info){
		InfoPanel.SetActive (true);
		UnityEngine.Debug.Log("********** "+info);
		//Text toChange = InfoPanel.GetComponent<Text> ();
		//UnityEngine.Debug.Log (toChange.ToString ());
		PlayerPrompt.text = info;
	}
	//exercises 1-whatever
	public void deactivateInfoPanel(){
		InfoPanel.SetActive (false);
	}
	//Game begins & stopwatch starts:
	public void startStopWatch(){
		timer.Start();
	}

	public void stopStopWatch(){
		timer.Stop ();
	}
}


