using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameController gameController;

    [SerializeField]
    private int _hearts;
    public Text HeartsLabel;

    [SerializeField]
    private int _score;
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
    void Start()
    {
        Hearts = 3;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
