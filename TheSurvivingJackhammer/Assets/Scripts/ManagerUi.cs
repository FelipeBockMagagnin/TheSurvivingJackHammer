using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUi : MonoBehaviour {

	public Text score;
	public Text HighScoreTxt;

	void Start(){		
		HighScoreManager.CheckScore();
		HighScoreManager.points = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + HighScoreManager.points.ToString();
		HighScoreTxt.text = "Best Score: " + (HighScoreManager.HighScore - 1).ToString();
	}


    //DESTROY BUTTONS ON START
    public Button[] DestroyButton;
    public Text[] texts;

    public void DestroyButtons()
    {
        foreach (Button b in DestroyButton)
        {
            Destroy(b.gameObject);
        }
        foreach (Text t in texts)
        {
            Destroy(t.gameObject);
        }
    }

}

