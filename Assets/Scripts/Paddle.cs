using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    // cached references
    GameSession gameSession;
    Ball ball;
    Rigidbody2D ballRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // Get objects
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
        ballRigidBody = ball.GetComponent<Rigidbody2D>();
        // Set minX/maxX
        minX = transform.lossyScale.x;
        maxX = screenWidthInUnits - transform.lossyScale.x;
        //if (gameSession.IsAutoPlayEnabled())
        //{
        //    minX = 1f;
        //    maxX = 15f;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXpos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXpos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            int gap = 1;
            return ball.transform.position.x + gap * ballRigidBody.velocity.normalized.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits; //mousePosInUnits
        }
    }
}
