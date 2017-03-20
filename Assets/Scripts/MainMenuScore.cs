using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScore : MonoBehaviour {

    [SerializeField]Text lastScore;
    [SerializeField]Text bestScore;

    // Use this for initialization
    void Start()
    {
        lastScore.text = "Last Score : " + Scooby_life.pts;
        if(File.Exists("scores.bin"))
        {
            using (BinaryReader reader = new BinaryReader(File.Open("scores.bin", FileMode.Open)))
            {
                bestScore.text = "Best Score : " + reader.ReadInt16().ToString();
            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
