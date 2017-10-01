using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{

    public Text highScore;

    // Use this for initialization
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        DestroyOtherCanvas();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Right");
    }

    /// <summary>
    /// Destroy the canvas that displays during game play. 
    /// </summary>
    private void DestroyOtherCanvas()
    {
        GameObject gameCanvas = GameObject.Find("Canvas");
        if (gameCanvas != null)
        {
            Destroy(gameCanvas);
        }
    }

}
