using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // function to load test_cube
    public void LoadCube()
    {
        SceneManager.LoadScene("test_Cube");
    }
    // other functions will have to reference scene name in order to load

}
