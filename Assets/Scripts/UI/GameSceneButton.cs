using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneButton : MonoBehaviour
{
    #region Unity function
    public void OnClickGameButton()
    {
        SceneManager.LoadScene("GameScene");
    }
    #endregion
}
