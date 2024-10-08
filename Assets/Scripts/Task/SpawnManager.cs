using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> playerSpawnList = new List<GameObject>();

    public static int greenPlayerCount = 0;
    public static int redPlayerCount = 0;
    public static int bluePlayerCount = 0;

    float duration;
    float elapsedTime;

   [SerializeField]
    private TMP_Text textMeshPro;
    [SerializeField]
    Button startButton,quitButton,settings,mainMenuButton,mainMenuGameplayButton;
    [SerializeField]
    GameObject MainMenu;
    [SerializeField]
    GameObject DisplaySettings;
    [SerializeField]
    GameObject GameConfig;
    [SerializeField]
    AudioSource music;
    [SerializeField]
    Slider soundSlider;

    [SerializeField]
    TMP_InputField gamePlaytime;
    [SerializeField]
    TMP_InputField spawntime;

    private void Awake()
    {
        music = GetComponent<AudioSource>();
        music.volume = 0f;
        music.Play();
    }

    private void OnEnable()
    {
        MainMenu.gameObject.SetActive(true);
        textMeshPro.gameObject.SetActive(false);
        DisplaySettings.SetActive(false);
        GameConfig.SetActive(false);
        startButton.onClick.AddListener(StartGame);
        settings.onClick.AddListener(Settings);
        quitButton.onClick.AddListener(QuitGame);
        mainMenuButton.onClick.AddListener(DisplayMainMenu);
        mainMenuGameplayButton.onClick.AddListener(DisplayMainMenu);
        
        soundSlider.value = 0;
        soundSlider.onValueChanged.AddListener(SoundVolume);



    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveAllListeners();
        settings.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
        mainMenuButton.onClick.RemoveAllListeners();
        mainMenuGameplayButton.onClick.RemoveAllListeners();
        soundSlider.onValueChanged.RemoveAllListeners();


    }

    private void DisplayMainMenu()
    {
        DestroyAll();
        StopAllCoroutines();
        textMeshPro.gameObject.SetActive(false);
        mainMenuGameplayButton.enabled = false;
        DisplaySettings.SetActive(false);
        MainMenu.SetActive(true);
        
    }

    void Settings()
    {
        mainMenuGameplayButton.enabled = false;
        MainMenu.SetActive(false);
        DisplaySettings.SetActive(true);
        GameConfig.SetActive(true);

    }

    private void SoundVolume(float arg0)
    {
       music.volume = arg0;
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        mainMenuGameplayButton.enabled = true;
        MainMenu.SetActive(false);
        duration = float.Parse(gamePlaytime.text) * 60;
        elapsedTime = float.Parse(spawntime.text);

        StartCoroutine(LoopForFiveMinuteCoroutine());

    }

    IEnumerator LoopForFiveMinuteCoroutine()
    {
        

        while (elapsedTime < duration)
        {
            int randomPlayer = Random.Range(0, playerSpawnList.Count); //choosing Random Player
            Vector3 randomPos = new Vector3(Random.Range(-40, 40), 1f, Random.Range(-40, 40));// Generating Random position for player
            yield return new WaitForSeconds(elapsedTime);
            Instantiate(playerSpawnList[randomPlayer], randomPos, Quaternion.identity);
            elapsedTime += elapsedTime + Time.deltaTime;
            yield return null;

        }

        StopAllCoroutines();
        Time.timeScale = 0f;  // Pause the game
        Debug.Log("Game Over");
        Debug.Log($"{bluePlayerCount} Blue Players");
        Debug.Log($"{redPlayerCount} Red Players");
        Debug.Log($"{greenPlayerCount} Green Players");

        if (bluePlayerCount > redPlayerCount)
        {
             if(bluePlayerCount > greenPlayerCount)
            {
                textMeshPro.color = Color.blue;
                textMeshPro.text = "Blue is the Winner";
                textMeshPro.gameObject.SetActive(true);

            }
            else
            {
                textMeshPro.color = Color.green;
                textMeshPro.text = "Green is the Winner";
                textMeshPro.gameObject.SetActive(true);

            }
        }
        else
        {
            if (redPlayerCount > greenPlayerCount)
            {
                textMeshPro.color = Color.red;
                textMeshPro.text = "Red is the Winner";
                textMeshPro.gameObject.SetActive(true);

            }
            else 
            {
                textMeshPro.color = Color.green;
                textMeshPro.text = "Green is the Winner";
                textMeshPro.gameObject.SetActive(true);

            }
        }


    }

    void DestroyAll()
    {
        Destroy(GameObject.FindWithTag("RedPlayer"));
        Destroy(GameObject.FindWithTag("GreenPlayer"));
        Destroy(GameObject.FindWithTag("BluePlayer"));


    }
}
