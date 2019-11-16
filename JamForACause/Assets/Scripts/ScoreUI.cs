using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int strikes;

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

            scoreText.text = "Score: " + score + "\nStrikes: " + strikes;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set starting score at 0
        score = 0;

        //Set starting strikes to 0
        strikes = 0;

        // Get score Text
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        scoreText.text = "Score: " + score + "\nStrikes: " + strikes;
    }

    // Update is called once per frame
    void Update()
    {
        if (strikes == 3)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    /// <summary>
    /// Updates score
    /// </summary>
    public void UpdateScore()
    {
        score++;

        // Get score Text
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        scoreText.text = "Score: " + score + "\nStrikes: " + strikes;
    }

    /// <summary>
    /// Updates strikes, checks if theres three strikes?
    /// </summary>
    public void UpdateStrikes()
    {
        strikes++;
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        scoreText.text = "Score: " + score + "\nStrikes: " + strikes;
    }
}
