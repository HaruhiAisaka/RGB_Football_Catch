using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public Transform cylinder;
    public Transform shootPoint;

    public Ball[] balls;

    public BallPrefab ballPrefab;
    
    public float rateOfFirePerMin;

    private float timePassed = 0;

    private const int SECONDS_PER_MINUTE = 60;

    void Start()
    {
        GetBallDataFromResources();
    }
    
    // Gets the ball data stored as JSON files in the resources folder.
    private void GetBallDataFromResources()
    {
        TextAsset[] ballJSONs = Resources.LoadAll<TextAsset>("Balls");
        balls = new Ball[ballJSONs.Length];
        for (int i = 0; i < ballJSONs.Length; i++)
        {
            string newJSON = ballJSONs[i].ToString();
            balls[i] = JsonUtility.FromJson<Ball>(newJSON);
        }
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 1 / (rateOfFirePerMin / SECONDS_PER_MINUTE))
        {
            InstantiateBall();
            timePassed = 0;
        }
    }

    private void InstantiateBall()
    {
        BallPrefab newBall = Instantiate(ballPrefab, this.gameObject.transform);
        Ball ballData = GetRandomBallData();
        newBall.SetBall(ballData);
        newBall.Shoot(GetDirectionFromRotation());
    }

    private Ball GetRandomBallData()
    {
        int index = Random.Range(0, balls.Length);
        return balls[index];
    }

    private Vector3 GetDirectionFromRotation()
    {
        return Vector3.Normalize(shootPoint.position - cylinder.position);
    }

}