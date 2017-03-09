using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuControl : MonoBehaviour {

    public Canvas QuitMenu;
    public Button PlayText;
    public Button QuitText;
	// Use this for initialization
	void Start () {

        QuitMenu = QuitMenu.GetComponent<Canvas>();
        PlayText = PlayText.GetComponent<Button>();
        QuitText = QuitText.GetComponent<Button>();
        QuitMenu.enabled = false;
	}

    public void ExitPress()
    {
        QuitMenu.enabled = true;
        PlayText.enabled = false;
        QuitText.enabled = false;

    }

    public void NoPress()
    {
        QuitMenu.enabled = false;
        PlayText.enabled = true;
        QuitText.enabled = true;
    }
	
    public void StartLevel()
    {
        SceneManager.LoadScene("Gestures");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
