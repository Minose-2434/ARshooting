using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneButton : MonoBehaviour
{
    #region Unity function
    public void OnClickMenuButton()
    {
        SceneManager.MoveGameObjectToScene(GameObject.Find("GameMaster"), SceneManager.GetActiveScene());
        SceneManager.LoadScene("MenuScene");
    }
    #endregion
}
