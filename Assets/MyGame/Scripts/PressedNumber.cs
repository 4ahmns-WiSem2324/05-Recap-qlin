using UnityEngine;

public class PressedNumber : MonoBehaviour
{
    public int number;
    public bool numberOne;
    public bool numberTwo;
    public PressNumberScript press;
    public int score;


    public void Number(int a)
    {
        number = a;

        if(number == 1 && press.gameStarted == false)
        {

            press.startGame++;


            if (press.startGame == 2)
            {
                press.numberText.text = "8888";
            }
            else if (press.startGame == 1)
            {
                press.numberText.text = "00:00";
            }
        }


        if (press.numberToPress == a && press.numberTwoToPress == 0)
        {
            press.loadNewNumber = true;
            score++;

            if(press.timeToLoad > 0.5f)
            {
                press.timeToLoad = press.timeToLoad - 0.5f;
            }
        }
        /*else if (press.numberToPress != a && press.gameStarted == true)
        {
            press.GameOver();
        }*/

        if (press.numberToPress == a && press.gameTwoStart >= 2)
        {
            numberOne = true;
        }

    }

    public void SecondNumber(int b)
    {
        if(number == 6)
        {
            press.gameTwoStart++;
        }

        if (press.numberTwoToPress == b && press.gameTwoStart >= 2)
        {
            numberTwo = true;
        }

        if (numberOne == true && numberTwo == true)
        {
            score++;
            press.loadNewTwoNumbers = true;
        }
    }




}
