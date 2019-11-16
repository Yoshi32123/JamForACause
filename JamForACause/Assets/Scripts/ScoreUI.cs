using UnityEngine.UI;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private int score;

    private Text scoreText;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            if (value >= 0)
                score = value;

            scoreText.text = "Score: " + score;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set starting score at 0
        score = 0;

        // Get score Text
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Updates score
    /// </summary>
    public void UpdateScore()
    {
        // Set starting score at 0
        score++;

        // Get score Text
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// Updates strikes, checks if theres three strikes?
    /// </summary>
    public void UpdateStrikes()
    {

    }
}
