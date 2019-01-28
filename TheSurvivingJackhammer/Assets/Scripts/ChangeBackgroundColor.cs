using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundColor : MonoBehaviour {

    int index;

	public Camera cam;
	public Color[] colorsPixel;
    public Color[] colorsPen;
    public Color[] colorsWaterColor;
    public GameObject creepyBackGround;
    public Color[] colorsNeon;   

    public void ChangeBackGroundIndex(){
		if(HighScoreManager.index == 0)
        {
            ChangeBackground(colorsPixel);
        }
        else if(HighScoreManager.index == 1)
        {
            ChangeBackground(colorsPen);
        }
        else if (HighScoreManager.index == 2)
        {
            ChangeBackground(colorsWaterColor);
        }
        else if (HighScoreManager.index == 3)
        {
            CreepyBackGround();
        }
        else if (HighScoreManager.index == 4)
        {
            ChangeBackground(colorsNeon);
        }
        else if (HighScoreManager.index == 5)
        {
            //
        }


        if(HighScoreManager.index != 3)
        {
            creepyBackGround.SetActive(false);
        }
	}

    void ChangeBackground(Color[] colors)
    {

        //diminui chance de repetir cor
        int thisTurnIndex = index;
        index = Random.Range(0, colors.Length);

        if (thisTurnIndex == index)
        {
            if (colors.Length == 1)
            {
                index = 0;
            }
            else
            {
                if (index == (colors.Length - 1))
                {
                    index--;
                }
                else
                {
                    index++;
                }
            }
        }



        //normal change of colors
        cam.backgroundColor = colors[index];
        if (index == (colors.Length - 1) || colors.Length == 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
    }

    void CreepyBackGround()
    {
        creepyBackGround.SetActive(true);
    }
}
