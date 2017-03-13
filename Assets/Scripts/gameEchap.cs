using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameEchap : MonoBehaviour {


    public Canvas QuitMenu;
    [SerializeField] AudioSource game_over;
    // Use this for initialization

    void Start()
    {

        QuitMenu = QuitMenu.GetComponent<Canvas>();
        QuitMenu.enabled = false;
    }

    public void ExitPress()
    {
        QuitMenu.enabled = true;

    }

    public void NoPress()
    {
        QuitMenu.enabled = false;
    }

    public void YesPress()
    {
        game_over.Play();
        SceneManager.LoadScene("SceneMenu");
        

    }

    public bool getQuitMenu() { return QuitMenu.enabled; }

    // Update is called once per frame
    void Update () {
		
	}
}
