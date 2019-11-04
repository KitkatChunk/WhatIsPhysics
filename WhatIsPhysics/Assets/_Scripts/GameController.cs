using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Abdulkarem Alani #300993768
/// This is a Game controller takes care of hearts and score UI and updates them. At game over scene if restart is presesed it loads the first level.
/// Assets were used from opengameart.
/// https://opengameart.org/content/2d-platform-ground-stone-tiles - Ground
///https://opengameart.org/content/krook-tree - Tree
///https://opengameart.org/content/simple-sky - Background
///https://opengameart.org/content/platformer-jumping-sounds -Jump sound
///https://opengameart.org/content/completion-sound -Coin Collect
///https://opengameart.org/content/animated-turtle -Turtle
/// </summary>

public class GameController : MonoBehaviour
{
    void Start()
    {
        Hearts = 3;
        Score = 0;
    }

    [SerializeField]
    private static int _hearts;
    public Text HeartsLabel;

    [SerializeField]
    private static int _score;
    public Text ScoreLabel;
    //setting hearts amount and loading gameover if hearts = 0.
    public int Hearts
    {
        get
        {
            return _hearts;
        }
        set
        {
            _hearts = value;
            if (_hearts <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
               HeartsLabel.text = "Hearts: " + _hearts.ToString();
            }


        }

    }
    // Score counter and updater 
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            ScoreLabel.text = "Score: " + _score.ToString();
        }



    }
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
