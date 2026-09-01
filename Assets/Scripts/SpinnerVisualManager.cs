using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class SpinnerVisualManager : MonoBehaviour
{
    public FortuneWheel fortuneWheel;
    public SpinnerParts spinnerParts;

    public Image circleBase;
    public Image arrow;

    public Sprite[] Circles;
    public Sprite[] Arrows;

    

    // Update is called once per frame
    public void Change()
    {
        if (fortuneWheel.round % 5 == 0 && fortuneWheel.round % 30 != 0)
        {
            circleBase.sprite = Circles[1];
            arrow.sprite = Arrows[1];
            spinnerParts.FillWheelRandomly();
        }
        else if (fortuneWheel.round % 5 == 0 && fortuneWheel.round % 30 == 0)
        {
            circleBase.sprite = Circles[2];
            arrow.sprite = Arrows[2];
            spinnerParts.FillWheelRandomly();
        }
        else
        {
            circleBase.sprite = Circles[0];
            arrow.sprite = Arrows[0];
            spinnerParts.FillWheelRandomly();
            spinnerParts.AssignDeath();
        }
        
    }
}
