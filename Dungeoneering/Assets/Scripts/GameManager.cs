using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject gameButtonPrefab;
    public GameObject scorePrefab;
    public GameObject GameOverPopup;
    
    public GameObject TryAgain;
    public GameObject Quit;
    public GameObject StartButton;

    public List<ButtonSetting> buttonSettings;

    public Transform gameFieldPanelTransform;

    List<GameObject> gameButtons;

    int bleepCount = 0;

    List<int> bleeps;
    List<int> playerBleeps;

    System.Random rg = new System.Random();

    bool inputEnabled = false;

    /*
    * Game creation
    */
    void Start() 
    {
        bleeps = new List<int>();
        playerBleeps = new List<int>();

        TryAgain.GetComponent<Button>().onClick.AddListener(() => {
            tryAgain();
        });
        Quit.GetComponent<Button>().onClick.AddListener(() => {
            quit();
        });

        gameButtons = new List<GameObject>();
        CreateScoreBoard(new Vector3(0,160));

        CreateGameButton(0, new Vector3(-64, 64));
        CreateGameButton(1, new Vector3(64, 64));
        CreateGameButton(2, new Vector3(-64, -64));
        CreateGameButton(3, new Vector3(64, -64));
        StartButton.SetActive(true);

        StartButton.GetComponent<Button>().onClick.AddListener(() => {
            StartButton.SetActive(false);
            StartCoroutine(SimonSays());
        });

    }

    void CreateScoreBoard(Vector3 position) 
    {
        GameObject ScoreBoard = Instantiate(scorePrefab, Vector3.zero, Quaternion.identity) as GameObject;

        ScoreBoard.transform.SetParent(gameFieldPanelTransform);
        ScoreBoard.transform.localPosition = position;
    }

    void CreateGameButton(int index, Vector3 position) 
    {
        GameObject gameButton = Instantiate(gameButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        gameButton.transform.SetParent(gameFieldPanelTransform);
        gameButton.transform.localPosition = position;

        gameButton.GetComponent<Image>().color = buttonSettings[index].normalColor;
        gameButton.GetComponent<Button>().onClick.AddListener(() => {
            OnGameButtonClick(index);
        });

        gameButtons.Add(gameButton);
    }

    /*
    * Game Execution
    */
    void PlayAudio(int index) 
    {
        float length = 0.5f;
        float frequency = 0.001f * ((float)index + 1f);

        AnimationCurve volumeCurve = new AnimationCurve(new Keyframe(0f, 1f, 0f, -1f), new Keyframe(length, 0f, -1f, 0f));
        AnimationCurve frequencyCurve = new AnimationCurve(new Keyframe(0f, frequency, 0f, 0f), new Keyframe(length, frequency, 0f, 0f));

        LeanAudioOptions audioOptions = LeanAudio.options();
        audioOptions.setWaveSine();
        audioOptions.setFrequency(44100);

        AudioClip audioClip = LeanAudio.createAudio(volumeCurve, frequencyCurve, audioOptions);

        LeanAudio.play(audioClip, 0.5f);
    }

    void OnGameButtonClick(int index) 
    {
        if(!inputEnabled) {
            return;
        }

        Bleep(index);
        playerBleeps.Add(index);

        if(bleeps[playerBleeps.Count - 1] != index) {
            GameOver();
            return;
        }

        if(bleeps.Count == playerBleeps.Count) {
            ScoreCounter.scoreValue = bleeps.Count;
            playerBleeps = new List<int>();
            StartCoroutine(SimonSays());
        }
    }

    IEnumerator SimonSays() 
    {
        inputEnabled = false;
        SetBleeps();

        yield return new WaitForSeconds(1f);

        for(int i = 0; i < bleeps.Count; i++) {
            Bleep(bleeps[i]);

            yield return new WaitForSeconds(0.6f);
        }

        inputEnabled = true;

        yield return null;
    }

    void Bleep(int index) 
    {
        LeanTween.value(gameButtons[index], buttonSettings[index].normalColor, buttonSettings[index].highlightColor, 0.25f).setOnUpdate((Color color) => {
            gameButtons[index].GetComponent<Image>().color = color;
        });

        LeanTween.value(gameButtons[index], buttonSettings[index].highlightColor, buttonSettings[index].normalColor, 0.25f)
            .setDelay(0.5f)
            .setOnUpdate((Color color) => {
                gameButtons[index].GetComponent<Image>().color = color;
            });

        PlayAudio(index);
    }

    void SetBleeps() 
    {
        if(bleepCount == 0)
        {
           for(int i = 0; i < 3; i++) {
            bleeps.Add(rg.Next(0, gameButtons.Count));
            bleepCount = 3;   
            } 
        }
        else
        {
            bleeps.Add(rg.Next(0, gameButtons.Count));
            bleepCount++; 
        }
    }

    /*
    * Game over and popup buttons
    */
    void GameOver() {
        GameOverPopup.SetActive(true);
        inputEnabled = false;

    }
    // TODO 
    void tryAgain()
    {
        ScoreCounter.scoreValue = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void quit()
    {
         #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
         #else
         Application.Quit();
         #endif
    }
}