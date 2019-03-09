using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] float maxSpeed = 15f;
    //float ballSpeed;
    //[SerializeField] float xVelocity;
    //[SerializeField] float yVelocity;
    [SerializeField] Vector2 objectVelocity;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        //Debug.Log(GetBallSpeed());
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y); // + paddleToBallVector.y
        //Vector2 ballPos = new Vector2(paddlePos.x, paddlePos.y + paddleToBallVector.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (UnityEngine.Random.Range(0f, randomFactor),
            UnityEngine.Random.Range(0f, randomFactor));
        Vector2 roofPush = new Vector2
            (0f,UnityEngine.Random.Range(0f, randomFactor+0.5f));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
            //Debug.Log(GetBallSpeed());
            if (transform.position.y >= 11.74f)
            {

                myRigidbody2D.velocity += roofPush;
            }
            if (myRigidbody2D.velocity.magnitude != maxSpeed)
            {
                myRigidbody2D.velocity = myRigidbody2D.velocity.normalized * maxSpeed;
            }
        }
    }

    public float GetBallSpeed()
    {
        return myRigidbody2D.velocity.magnitude; //ballSpeed
    }
}
