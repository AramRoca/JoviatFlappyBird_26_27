using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int score = 0;
    public GameObject gameOverPanel;
    public GameObject pipeSpawner;
    public TextMeshProUGUI  scoreText;
    public AudioClip gameOverAudio;
    public AudioClip coinsAudio;
    public AudioClip newRecord;
    public GameObject player;
    public TextMeshProUGUI maxScoreText;
    private int max;
    
    void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateScoreInfo();
        max = PlayerPrefs.GetInt("MaxScore", 0);
        maxScoreText.SetText("Max: " + PlayerPrefs.GetInt("MaxScore", 0));
    }

    void UpdateScoreInfo()
    {
        scoreText.SetText("Score: " + score);
        if (score >= max)
        {
            max = score;
            
            maxScoreText.SetText("Max: " + PlayerPrefs.GetInt("MaxScore", 0));
            GetComponent<AudioSource>().PlayOneShot(newRecord);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        score += amount;
        GetComponent<AudioSource>().PlayOneShot(coinsAudio);
        UpdateScoreInfo();
        Debug.Log(score);
    }


    public void StopGame()
    {
        player.GetComponent<Animator>().SetTrigger("Die");
        Debug.Log("Game stopped");
        if (score >= max)
        {
            max = score;
            PlayerPrefs.SetInt("MaxScore", max);
            PlayerPrefs.Save();
        }
        gameOverPanel.SetActive(true);
        
        GetComponent<AudioSource>().PlayOneShot(gameOverAudio);

        //Buscar todos los pipe y destruir su componente Pipe
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("PIPE");
        foreach (GameObject pip in pipes)
        {
            Destroy(pip.GetComponent<Pipe>());
        }
        Destroy(pipeSpawner.GetComponent<PipeSpawner>());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
