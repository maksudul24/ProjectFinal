using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startmenusript : MonoBehaviour
{
    
    public GameObject op;
    public GameObject main;
    public void PlayGame() 
    {
        SceneManager.LoadScene("Ingame");
    }

    public void MultiPlayer(){
        SceneManager.LoadScene("Multiplayer");
        CommonScript.isMultiplayer = true;

    }

    public void CoMultiplayer(){
        SceneManager.LoadScene("Multiplayer");
        CommonScript.isMultiplayer = true;
        CommonScript.isCO_Op = true;

    }
    public void OnClickCredit(){
        SceneManager.LoadScene("About");
    }
    public void OnClickOption(){
        main.SetActive(false);
        op.SetActive(true);
        
    }
    public void OnClickBackFromOption(){
        main.SetActive(true);
        op.SetActive(false);
    }
    public void QuitGame() 
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }
}
