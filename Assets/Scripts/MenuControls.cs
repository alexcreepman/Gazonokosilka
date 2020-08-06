using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControls : MonoBehaviour
{
    public void ShortPlay()
    {
        SceneManager.LoadScene("ShortSquare");
    }
    public void LongPlay()
    {
        SceneManager.LoadScene("LongSquare");
    }
    public void MazePlay()
    {
        SceneManager.LoadScene("Maze");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
