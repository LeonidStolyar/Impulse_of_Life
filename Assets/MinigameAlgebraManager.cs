using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;
using System;
using Random = UnityEngine.Random;

[Serializable]
public class FigureParameters
{
    public Sprite spriteFigure;
    public int countAngles;
    public int countFigures;
    public int countIntersection;
    public bool isRegular;
}
public class MinigameAlgebraManager : MonoBehaviour
{
    [SerializeField] private Button buttonNumber;
    [SerializeField] private Button startButton;
    [SerializeField] private GridLayoutGroup gridButtons;
    [SerializeField] private TextMeshProUGUI textTask;
    [SerializeField] private TextMeshProUGUI textTimerEndGame;
    [SerializeField] private TextMeshProUGUI textScorePlayer;
    [SerializeField] private TextMeshProUGUI textScoreMax;
    [SerializeField] private int durationGame;
    [SerializeField] private int countButtons;
    

    [SerializeField] private GameObject panelMinigame;
    private int scorePlayer;
    private int scoreMax;
    public float timerEndGame;
    private string task;
    

    private List<int> correctNumbers;
    private List<int> allNumbers;
    private List<UnityAction> listMinigames;
    private List<Button> listButtons;

    private Color colorCorrectButton;
    private Color colorIncorrectButton;
    private Color colorDefaultButton;
    private bool minigameIsPlay;
    private void Awake() {
        listMinigames = new List<UnityAction>
        {
            MinigamePrimeNumbers,
            MinigameDivisibleNumbers,
            MinigameDivisorNumbers
        };

        correctNumbers = new List<int>();

        listButtons = new List<Button>();

        colorCorrectButton = new Color(0f, 1, 0f);
        colorIncorrectButton = new Color(1, 0f, 0f);
        colorDefaultButton = Color.white;

        allNumbers = Enumerable.Range(1, countButtons).ToList();

        AddButtons();

        //StartGame();
    }

    void Update()
    {
        ChangeTimerEndGame();
    }
    private void ChangeTimerEndGame()
    {
        if(!minigameIsPlay) return;
        if (timerEndGame > 0)
        {
            timerEndGame -= Time.deltaTime;
            ChangeTimerEndGame((int)timerEndGame);
        }
        else
        {
            minigameIsPlay = false;
            EndGame();
        }
    }
    private void AddButtons()
    {
        for (int i = 0; i < countButtons; i++) 
        {
            Button button = Instantiate(buttonNumber, gridButtons.transform);
            button.onClick.AddListener(() => EventNumberPlayer(button));
            listButtons.Add(button);
        }
    }
    // Update is called once per frame
    public void ShowMinigamePanel()
    {
        panelMinigame.SetActive(true);
        gridButtons.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
    }

    public void HideMinigamePanel()
    {
        panelMinigame.SetActive(false);

        timerEndGame = 0f;
        scorePlayer = 0;
        minigameIsPlay = false;
    }

    public void StartGame()
    {
        gridButtons.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);

        timerEndGame = durationGame;
        minigameIsPlay = true;
        scorePlayer = 0;

        StartMinigame();

    }
    private void EndGame()
    {
        gridButtons.gameObject.SetActive(false);
        textTask.text = $"Ваш счёт: {scorePlayer}";
        startButton.gameObject.SetActive(true);
    }
    private void StartMinigame()
    {
        task = "";
        correctNumbers.Clear();

        UnityAction minigame = ChooseRandomMinigame();
        minigame.Invoke();

        List<int> randomNumbers = allNumbers.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < countButtons; i++)
        {
            listButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = randomNumbers[i].ToString();
            listButtons[i].image.color = colorDefaultButton;
        }

        textTask.text = task;
        
    }
    public UnityAction ChooseRandomMinigame()
    {
        int randomIndex = Random.Range(0, listMinigames.Count);
        return listMinigames[randomIndex];
    }
    private void MinigamePrimeNumbers() // простые числа 
    {
        List<int> primeNumbers = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23};

        correctNumbers = primeNumbers;

        task = "Найдите все простые числа";
    }
    private void MinigameDivisibleNumbers() // числа, которые делятся на какое-то определенное число
    {
        
        List<int> dividerNumbers = new List<int> {3, 4, 5, 6, 7, 8, 9, 10};

        int randomDividerIndex = Random.Range(0, dividerNumbers.Count);
        int dividerNumber = dividerNumbers[randomDividerIndex];

        foreach (var num in allNumbers)
        {
            if (num % dividerNumber == 0)
            {
                correctNumbers.Add(num);
            }
        }
        
        task = $"Найдите все числа, которые делятся без остатка на {dividerNumber}";

    }
    private void MinigameDivisorNumbers()
    {
        List<int> divisibleNumbers = new List<int> {6, 10, 12, 15, 24};
        int randomDivisibleIndex = Random.Range(0, divisibleNumbers.Count);
        int divisibleNumber = divisibleNumbers[randomDivisibleIndex];

        for (int i = 1; i <= divisibleNumber; i++)
        {
            if (divisibleNumber % i == 0){
                correctNumbers.Add(i);
            }
        }

        task = $"Найдите все делители числа {divisibleNumber}";

    }
    private void EventNumberPlayer(Button button)
    {
        Debug.Log($"11122");
        if (button.image.color != colorDefaultButton) return;

        TextMeshProUGUI textMeshPro = button.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(textMeshPro);
        if (textMeshPro == null) return;

        int numberPlayer = int.Parse(textMeshPro.text);
        int indexNumberPlayer = correctNumbers.IndexOf(numberPlayer);
        Debug.Log($"{indexNumberPlayer}");
        if (indexNumberPlayer != -1)
        {
            button.GetComponent<Image>().color = colorCorrectButton;
            correctNumbers.RemoveAt(indexNumberPlayer);
            scorePlayer += 1;

            ChangeScorePlayer(scorePlayer);

            if (correctNumbers.Count == 0){
                StartMinigame();
            }
        }
        else
        {
            button.GetComponent<Image>().color = colorIncorrectButton;
            timerEndGame -= 5;
        }
    }

    private void ChangeScorePlayer(int score)
    {
        textScorePlayer.text = $"Счёт: {score}";
    }
    private void ChangeScoreMax(int score)
    {
        textScoreMax.text = $"Максимум: {score}";
    }
    private void ChangeTimerEndGame(int timer)
    {
        textTimerEndGame.text = $"Осталось: {timer}";
    }

    
}
