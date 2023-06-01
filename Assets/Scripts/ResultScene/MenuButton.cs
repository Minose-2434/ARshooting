using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    #region Unity function
    public void OnClickMenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
    #endregion
}
