using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public GameObject Bronchial;
    public GameObject BronchoVesicular;
    public GameObject Tracheal;
    public GameObject Vesicular;
    public GameObject Wheezing;
    public GameObject Heartbeat;
    // Use this for initialization
    void Start () {

        Bronchial = GameObject.Find("Bronchial");
        BronchoVesicular = GameObject.Find("BronchoVesicular");
        Tracheal = GameObject.Find("Tracheal");
        Vesicular = GameObject.Find("Vesicular");
        Wheezing = GameObject.Find("Wheezing");
        Heartbeat = GameObject.Find("Heartbeat");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    #region VOICE_INPUT

    public void playBronchialMethod()
    {
        Bronchial.GetComponent<AudioSource>().enabled = true;
        BronchoVesicular.GetComponent<AudioSource>().enabled = false;
        Tracheal.GetComponent<AudioSource>().enabled = false;
        Vesicular.GetComponent<AudioSource>().enabled = false;
        Wheezing.GetComponent<AudioSource>().enabled = false;
    }

    public void playBronchoVesicularMethod()
    {
        Bronchial.GetComponent<AudioSource>().enabled = false;
        BronchoVesicular.GetComponent<AudioSource>().enabled = true;
        Tracheal.GetComponent<AudioSource>().enabled = false;
        Vesicular.GetComponent<AudioSource>().enabled = false;
        Wheezing.GetComponent<AudioSource>().enabled = false;
    }

    public void playTrachealMethod()
    {
        Bronchial.GetComponent<AudioSource>().enabled = false;
        BronchoVesicular.GetComponent<AudioSource>().enabled = false;
        Tracheal.GetComponent<AudioSource>().enabled = true;
        Vesicular.GetComponent<AudioSource>().enabled = false;
        Wheezing.GetComponent<AudioSource>().enabled = false;
    }

    public void playVesicularMethod()
    {
        Bronchial.GetComponent<AudioSource>().enabled = false;
        BronchoVesicular.GetComponent<AudioSource>().enabled = false;
        Tracheal.GetComponent<AudioSource>().enabled = false;
        //Vesicular.SetActive(true);
        Vesicular.GetComponent<AudioSource>().enabled = true;
        Wheezing.GetComponent<AudioSource>().enabled = false;
    }

    public void playWheezingMethod()
    {
        Bronchial.GetComponent<AudioSource>().enabled = false;
        BronchoVesicular.GetComponent<AudioSource>().enabled = false;
        Tracheal.GetComponent<AudioSource>().enabled = false;
        Vesicular.GetComponent<AudioSource>().enabled = false;
        Wheezing.GetComponent<AudioSource>().enabled = true;
    }

    public void stopBreathingMethod()
    {
        Bronchial.GetComponent<AudioSource>().enabled = false;
        BronchoVesicular.GetComponent<AudioSource>().enabled = false;
        Tracheal.GetComponent<AudioSource>().enabled = false;
        Vesicular.GetComponent<AudioSource>().enabled = false;
        Wheezing.GetComponent<AudioSource>().enabled = false;
    }

    public void playHeartbeatMethod()
    {
        Heartbeat.GetComponent<AudioSource>().enabled = true;
    }

    public void stopHeartbeatMethod()
    {
        Heartbeat.GetComponent<AudioSource>().enabled = false;
    }

    #endregion
}
