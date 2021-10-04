using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LoadSceneManager : MonoBehaviour
{
    public void SceneToLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void SceneToLevelOne()
    {
        SceneManager.LoadScene(2);
    }

}
