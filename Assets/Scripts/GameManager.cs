using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject puzzlePrefab;
    public GameObject[] piecePrefabs = new GameObject[9];
    public Sprite photo;
    GameObject[] _puzzlePieces = new GameObject[9];

    public Text scoreOutput;

    public Canvas gameOverUI;

    bool gameOver;
    float _timer;
    public Text timerOutput;
    public int finishCount;

    void Awake()
    {
        int pieceCount = 0;
        for (int col = 0; col < 3; col++)
        {
            for (int row = 0; row < 3; row++)
            {
                GameObject piece = Instantiate(piecePrefabs[pieceCount]);
                piece.transform.position = new Vector3(Random.Range(-6.5f, 6.5f), Random.Range(-2.5f, 0f), 0);
                _puzzlePieces[pieceCount] = piece;
                pieceCount++;
            }
        }
    }

    void Start()
    {
        gameOver = false;
        _puzzlePieces[2].transform.position = Vector3.zero;
    }

    void Update()
    {
        if (finishCount == 9)
            GameOver();
        else
            _timer += Time.deltaTime;

        timerOutput.text = ((int) _timer).ToString();
    }

    void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            int finalScore = (60 - (int)_timer) * 10;
            gameOverUI.gameObject.SetActive(true);
            scoreOutput.text = finalScore.ToString();
            StartCoroutine(SendScore(finalScore));
        }
    }

    IEnumerator SendScore(int value)
    {
        Debug.Log(value);
        WWWForm form = new WWWForm();
        form.AddField("game", "Puzzle");
        form.AddField("score", value);

        WWW www = new WWW("https://edgelessnetwork.com/app/views/sendScore.php", form);
        yield return www;
    }
}
