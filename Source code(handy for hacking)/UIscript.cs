using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NUnit.Framework.Interfaces;

[System.Serializable]
public class Table
{
    public string[] table;
}
public class UIscript : MonoBehaviour
{
    [Header("UI Elements")]
    public List<GameObject> Menus;
    public int GameSceneIndex = 1;
    [Header("Level config:")]
    public List<GameObject> LevelButtons = new List<GameObject>();
    public GameObject LevelButton;
    public Transform Content;
    [Header("Settings config:")]
    public GameObject SettingsUI;
    public Slider RayCountSlider;
    public TextMeshProUGUI RayCountText;
    public Slider RayThicknessSlider;
    public TextMeshProUGUI RayThicknessText;
    [Header("Online config:")]
    [Header("Level list")]
    public List<GameObject> OnlineButtons = new List<GameObject>();
    public Transform ContentOnline;
    public TMP_InputField LevelSearch;
    public string[] OnlineLevels;
    [Header("Default values")]
    public int DefaultRayCount = 720;
    public float DefaultRayThickness = 0.1f;
    void Start()
    {
        if (!PlayerPrefs.HasKey("RayCount"))
        {
            PlayerPrefs.SetInt("RayCount", DefaultRayCount);
        }
        if (!PlayerPrefs.HasKey("RayThickness"))
        {
            PlayerPrefs.SetFloat("RayThickness", DefaultRayThickness);
        }
    }
    // local levels
    public void Levels()
    {
        // get all level names 
        TextAsset[] text = Resources.LoadAll<TextAsset>("Levels/");

        var sorted = text.Where(x => int.TryParse(x.name, out _))
        .OrderBy(t => int.Parse(t.name));

        foreach (GameObject Lv in LevelButtons)
        {
            Destroy(Lv);
        }

        LevelButtons.Clear();

        // spawn buttons
        foreach (TextAsset textAsset in sorted)
        {
            if (int.TryParse(textAsset.name, out int id))
            {
                GameObject button = Instantiate(LevelButton, Content);
                button.GetComponent<Button>().onClick.AddListener(() => TryLoadLocalLevel(id));
                TextMeshProUGUI textMesh = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                textMesh.text = "Level " + id;
                LevelButtons.Add(button);
            }
        }
        
        ChangeMenu(1);
    }
    // load a level
    public void TryLoadLocalLevel(int level)
    {
        RuntimeData.id = level;
        RuntimeData.type = 0;
        SceneManager.LoadScene(GameSceneIndex);
    }
    public void TryLoadOnlineLevel(string level)
    {
        RuntimeData.url = Server.url + "/" + level + ".json";
        RuntimeData.type = 1;
        SceneManager.LoadScene(GameSceneIndex);
    }
    public void EnterEditor(string url)
    {
        RuntimeData.url = url;
        RuntimeData.type = 2;
        SceneManager.LoadScene(GameSceneIndex);
    }

    public void Main()
    {
        ChangeMenu(0);
    }
    public void Settings()
    {
        ChangeMenu(2);

        int RayCount = PlayerPrefs.GetInt("RayCount");
        float RayThickness = PlayerPrefs.GetFloat("RayThickness");

        RayCountSlider.value = RayCount;
        RayThicknessSlider.value = RayThickness;
    }
    public void Online()
    {
        ChangeMenu(3);
        
    }
    public void LevelList()
    {
        ChangeMenu(4);
        StartCoroutine(GetLevelList());
    }
    public void SearchLevels()
    {
        string text = LevelSearch.text;

        foreach(GameObject go in OnlineButtons)
        {
            go.SetActive(go.name.Contains(text));
        }
    }
    // get all avaible online levels from table
    // LOE !!! HIER
    IEnumerator GetLevelList()
    {
        UnityWebRequest unityWebRequest = UnityWebRequest.Get(Server.table);
        yield return unityWebRequest.SendWebRequest();
        if (unityWebRequest.result != UnityWebRequest.Result.Success)
        {
            // unity why?
            Debug.LogWarning("Load Online Level Error: "+ unityWebRequest.error);
        }

        string json = unityWebRequest.downloadHandler.text;

        Table wrapper = JsonUtility.FromJson<Table>(json);

        OnlineLevels = wrapper.table;

        foreach (GameObject Lv in OnlineButtons)
        {
            Destroy(Lv);
        }

        OnlineButtons.Clear();

        // spawn buttons
        foreach (string level in OnlineLevels)
        {
            GameObject button = Instantiate(LevelButton, ContentOnline);
            button.GetComponent<Button>().onClick.AddListener(() => TryLoadOnlineLevel(level));
            TextMeshProUGUI textMesh = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            textMesh.text = level;
            button.name = level;
            OnlineButtons.Add(button);
        }
    }
    void LateUpdate()
    {
        if (SettingsUI.activeSelf)
        {
            // settings for light
            PlayerPrefs.SetInt("RayCount", ((int)RayCountSlider.value));

            RayCountText.text = "Ray count: "+RayCountSlider.value;

            PlayerPrefs.SetFloat("RayThickness", RayThicknessSlider.value);
            RayThicknessText.text = $"Ray thickness: {RayThicknessSlider.value:F2}";
        }
    }
    public void Exit()
    {
        // NOOO WHY ARE YA LEAVING????
        Application.Quit();
    }
    public void DefaultSettings()
    {
        PlayerPrefs.SetInt("RayCount", DefaultRayCount);
        PlayerPrefs.SetFloat("RayThickness", DefaultRayThickness);

        RayCountSlider.value = DefaultRayCount;
        RayThicknessSlider.value = DefaultRayThickness;
    } 
    void ChangeMenu(int id)
    {
        for (int i = 0; i < Menus.Count; i++)
        {
            Menus[i].SetActive(i == id);
        }
    }
}
public static class RuntimeData
{
    public static int type = 0;
    public static int id = 1;
    public static string url = "";
}
