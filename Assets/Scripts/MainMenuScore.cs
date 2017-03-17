using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScore : MonoBehaviour {

    [SerializeField]Text lastScore;
    [SerializeField]Text bestScore;

    // Use this for initialization
    void Start()
    {

        lastScore.text = "Last Score : " + Scooby_life.pts;
        bestScore.text = "Best of Session : " + Scooby_life.best_pts;

    }
	// Update is called once per frame
	void Update () {
		
	}
}
