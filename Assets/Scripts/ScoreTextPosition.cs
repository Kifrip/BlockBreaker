using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ScoreTextPosition : MonoBehaviour
{
    RectTransform rectTransform;
    TextMeshProUGUI scoreText;
    bool positionChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (positionChanged == false)
        {
            if (SceneManager.GetActiveScene().name == "Success Screen")
            {
                UpdateTextPosition(0, 110);
            }
            else if(SceneManager.GetActiveScene().name == "Game Over")
            {
                UpdateTextPosition(0, 64);
            }

        }
    }

    void UpdateTextPosition(float x, float y)
    {
        rectTransform.anchoredPosition = new Vector2(x, y);
        scoreText.alignment = TextAlignmentOptions.Center;
        positionChanged = true;
        Debug.Log("Position was changed");
    }
}
