using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//show the main Scene
public class MainSc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Loads(){
        SceneManager.LoadScene("DemoScene");
    }

    //exite the game
    public void QuitGame(){
        Application.Quit();
    }

    //move to displaying the main menu
    public void LoadsMain(){
        SceneManager.LoadScene("ManMenu");
    }
}
