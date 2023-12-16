using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;
    public GameObject gameOverText;
    public TextMeshProUGUI ScoreText;
    public Text scoreText;
    public static GameControl instance;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    private int score = 0;
    public AudioClip scoresound;
    AudioSource audioSource;
    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void QbbyScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        ScoreText.text = "Score" + score.ToString();
        PlaySound(scoresound);
    }
    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);

    }
}
