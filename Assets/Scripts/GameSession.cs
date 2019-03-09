using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    //[SerializeField] GameObject textOjbject;
    [SerializeField] bool isAutoPlayEnabled;

    [SerializeField] float ballSpeed;

    // cached references
    Ball ball;

    // state variables
    [SerializeField] int currentScore = 0;


    private void Awake()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);

        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }

        //if (SceneManager.GetActiveScene().name == "Success Screen")
        //{
        //    Transform textObjectTransform = transform.GetChild(0).GetChild(0);
        //    textObjectTransform.localPosition = new Vector3(0, 180, 0);
        //    //textOjbject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 180);
        //    //kek.anchoredPosition = new Vector2(0, 180);
        //}

    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ball = FindObjectOfType<Ball>();
        Time.timeScale = gameSpeed;
        ShowBallSPeed();
        //Transform textObjectTransform = transform.GetChild(0).GetChild(0);
        //Debug.Log(textObjectTransform.localPosition);

    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void ShowBallSPeed()
    {
        if (GameObject.Find("Ball") != null)
        {
            ballSpeed=ball.GetBallSpeed();
        }
    }
}
