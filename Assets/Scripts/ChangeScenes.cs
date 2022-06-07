using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void MoveToScene(int SceneID)
    {
        Debug.Log("Changing...");
        SceneManager.LoadScene(SceneID);
    }
}
