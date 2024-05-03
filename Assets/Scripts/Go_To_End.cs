using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_To_End : MonoBehaviour
{
    public void end()
    {
        SceneManager.LoadScene("End_Scene");
    }

}
