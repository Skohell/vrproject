using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScore : MonoBehaviour {

    [SerializeField]Text var_lastScore;
    [SerializeField]Text var_bestScore;
    [SerializeField]Text lastScore;
    [SerializeField]Text bestScore;
    [SerializeField]Canvas MenuBest;

    // Use this for initialization
    void Start()
    {
        MenuBest.enabled = false;
        var_lastScore.text = Scooby_life.pts.ToString();
        if(File.Exists("scores.bin"))
        {
            using (BinaryReader reader = new BinaryReader(File.Open("scores.bin", FileMode.Open)))
            {
                var_bestScore.text = reader.ReadInt16().ToString();
            }
        }
        if(var_lastScore == var_bestScore)
        {
            MenuBest.enabled = true;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
