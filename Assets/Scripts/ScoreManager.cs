using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    private int initialScore = 0;
    private int currentScore;
    private int maxScore = 1000;

    [SerializeField] private int scoreToAdd = 100;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Slider scoreBar;

    //private GameObject scoreSlider;

    public static  ScoreManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }



        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", initialScore);
        }

        //currentScore = PlayerPrefs.GetInt("Score");
        initialScore = 0;
        currentScore = initialScore;
        scoreBar.value = (float)PlayerPrefs.GetInt("Score") / 1000;
        text.text = PlayerPrefs.GetInt("Score") + "/" + maxScore;

        print(PlayerPrefs.GetInt("Score"));
        print((float)PlayerPrefs.GetInt("Score") / 1000);
    }
    void Start()
    {
        scoreBar = FindObjectOfType<Slider>();
        text = scoreBar.GetComponentInChildren<TextMeshProUGUI>();
    }


    public void UpdateScore()
    {
        //currentScore += scoreToAdd;
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreToAdd);
        //text.text = PlayerPrefs.GetInt("Score").ToString() + "/" + maxScore;
        //float barScore = (float)currentScore / 1000;
        //scoreBar.value = (float)PlayerPrefs.GetInt("Score") / 1000;

        print(PlayerPrefs.GetInt("Score"));
        //print(scoreBar.value);

        if(PlayerPrefs.GetInt("Score") >= maxScore)
        {
            currentScore = initialScore;
            PlayerPrefs.SetInt("Score", currentScore);
            //text.text = PlayerPrefs.GetInt("Score") + "/" + maxScore;
            //scoreBar.value = PlayerPrefs.GetInt("Score");
        }
    }
}
