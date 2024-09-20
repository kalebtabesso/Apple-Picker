using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _SCORE = 10;

    private Text txtCom;

    void Awake()
    {
        _UI_TEXT = GetComponent<Text>();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            _SCORE = PlayerPrefs.GetInt("HighScore");
        }

        PlayerPrefs.SetInt("HighScore", _SCORE);
    }

    static public int SCORE {
        get {
            return (_SCORE);
        }
        set {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", _SCORE);
            _UI_TEXT.text = "High Score: " + value.ToString("#,0");
        }
    }

    static public void TRY_SET_HIGH_SCORE(int score)
    {
        if (score > _SCORE)
        {
            SCORE = score;
        }
    }

    [Tooltip("Reset the high score")]
    public bool resetHighScore = false;

    void OnDrawGizmos()
    {
        if (resetHighScore)
        {
            PlayerPrefs.SetInt("HighScore", 10);
            resetHighScore = false;
            Debug.LogWarning("High score reset to 10");
        }
    }
}
