using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GaneOverButton : MonoBehaviour
{
    #region Unity function
    public void OnClickGameOverButton()
    {
        SceneManager.LoadScene("ResultScene");
    }
    #endregion
}
