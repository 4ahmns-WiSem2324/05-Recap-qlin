using System.Collections;
using UnityEngine;
using TMPro;

public class PressNumberScript : MonoBehaviour
{
    public int numberToPress;
    public int numberTwoToPress;
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI numberTwoText;
    public bool gameStarted;
    public PressedNumber pressed;
    public bool loadNewNumber = false;
    public int startGame;
    public float time;
    public float timeToLoad;
    public AudioClip gameOverSound;
    public AudioSource audioSource;
    public float volume;
    public bool loadNewTwoNumbers;
    public int gameTwoStart;
    public GameObject textTwo;
    public bool chooseAble;
    public bool startGameTwo;
    private void Start()
    {
        startGame = 0;
        textTwo.SetActive(false);
        chooseAble = true;
        startGameTwo = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(startGame >= 2 && gameStarted == false && chooseAble == true)
        {
            gameStarted = true;
            //loadNewNumber = true;
            chooseAble = false;
        }


        if(gameTwoStart >= 2 && startGameTwo == true)
        {
            Debug.Log("Aus");
            loadNewTwoNumbers = true;
            startGameTwo = false;
        }
        else if(gameTwoStart == 1 && gameStarted == true)
        {
            Debug.Log("geführt");
            loadNewNumber = true;
            gameStarted = false;
        }



        if (loadNewNumber == true)
        {
            StopAllCoroutines();
            loadNewNumber = false;
            loadNewTwoNumbers = false;

            StartCoroutine(Wait());
        }

        if (loadNewTwoNumbers == true)
        {
            StopAllCoroutines();
            pressed.numberOne = false;
            pressed.numberTwo = false;
            loadNewNumber = false;
            loadNewTwoNumbers = false;
            textTwo.SetActive(true);
            StartCoroutine(SecondGame());
        }
    }

    IEnumerator Wait()
    {
        loadNewNumber = false;
        numberText.text = " ";
        yield return new WaitForSecondsRealtime(timeToLoad);
        numberToPress = Random.Range(1,7);
        numberText.text = numberToPress.ToString();
        yield return new WaitForSecondsRealtime(time);
        GameOver();
    }

    IEnumerator SecondGame()
    {
        loadNewNumber = false;
        numberText.text = " ";
        loadNewTwoNumbers = false;
        numberTwoText.text = " ";
        yield return new WaitForSecondsRealtime(1.5f);
        numberToPress = Random.Range(1, 7);
        numberText.text = numberToPress.ToString();

        numberTwoToPress = Random.Range(1,7);
        numberTwoText.text = numberTwoToPress.ToString();
        yield return new WaitForSecondsRealtime(2f);
        GameOver();
    }


    public void GameOver()
    {
        StopAllCoroutines();
        audioSource.PlayOneShot(gameOverSound, volume);
        startGameTwo = true;
        numberToPress = 0;
        numberTwoToPress = 0;
        gameTwoStart = 0;
        chooseAble = true;
        textTwo.SetActive(false);
        loadNewTwoNumbers = false;
        startGame = 0;
        gameStarted = false;
        numberText.text = "0" + pressed.score.ToString();
        pressed.score = 0;
        pressed.numberOne = false;
        pressed.numberTwo = false;
    }
}
