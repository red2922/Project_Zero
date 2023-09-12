using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // function to load Main_Game
    public void LoadGame()
    {
        SceneManager.LoadScene("Main_Game");
    }
    // other functions will have to reference scene name in order to load

}
