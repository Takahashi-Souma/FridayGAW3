using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("参照")]
    public GameObject[] packages;
    public GameObject[] deliveryPoints;

    [Header("UI")]
    public TMP_Text scoreText;  // Text → TMP_Text
    public TMP_Text carryText;  // Text → TMP_Text
    public TMP_Text timeText;   // Text → TMP_Text

    [Header("設定")]
    public float timeLimit = 60f;

    int currentPackageIndex = -1;
    int score = 0;
    float time;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        time = timeLimit;
        SpawnNext();
        UpdateUI();
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
            GameOver();
        }

        timeText.text = "Time: " + time.ToString("F1");
    }

    public void PickPackage(int index, GameObject obj)
    {
        if (currentPackageIndex != -1) return;

        currentPackageIndex = index;
        obj.SetActive(false);

        UpdateUI();
    }

    public void TryDelivery(int index)
    {
        if (currentPackageIndex == -1) return;

        if (index == currentPackageIndex)
        {
            score++;
            currentPackageIndex = -1;
            SpawnNext();
        }
        else
        {
            Debug.Log("ミス");
        }

        UpdateUI();
    }

    void SpawnNext()
    {
        foreach (var p in packages) p.SetActive(false);
        foreach (var d in deliveryPoints) d.SetActive(false);

        int next = Random.Range(0, packages.Length);

        packages[next].SetActive(true);
        deliveryPoints[next].SetActive(true);
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;

        if (currentPackageIndex == -1)
            carryText.text = "None";
        else
            carryText.text = "Carry: " + currentPackageIndex;
    }

    void GameOver()
    {
        Debug.Log("ゲーム終了 / Score: " + score);
        enabled = false;
    }
}