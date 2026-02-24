using System.Collections.Generic;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor.PackageManager;
using NUnit.Framework.Interfaces;
using UnityEngine.SceneManagement;

public class Gamescript : MonoBehaviour
{
    [Header("Level Presets:")]
    public Material material;
    public float Zspawn = 0;
    public SpriteRenderer Background;
    public GameObject LightPrefab;
    public GameObject ReceiverPrefab;
    public GameObject TextPrefab;
    [Header("Set On Load")]
    public List<GameObject> Receivers;
    public List<GameObject> Objects;
    public List<GameObject> Lights;
    public List<GameObject> Texts;

    public static Gamescript game;
    [System.Serializable]
    public class LevelData
    {
        // level config
        public string name;
        public float size = 1f;
        public float bgR=0.09433959f, bgG=0.09433959f, bgB=0.09433959f,bgA=1;

        //objects

        public List<Light> lights;

        public List<Receiver> receivers;

        public List<MeshObject> meshObjects;

        public List<Text> texts;
    }
    [System.Serializable]
    public class Text
    {
        public float size = 36f;
        public float r=1,g=1,b=1,a=1;
        public float x,y;
        public string text = "Lux";
    }
    [System.Serializable]
    public class Light
    {
        public float r=1, g=0.6117804f, b=0, a=0.0627451f;
        public float x,y;
    }
    [System.Serializable]
    public class Receiver
    {
        public bool light = true;
        public float x,y;
    }
    [System.Serializable]
    public class MeshObject
    {
        public bool mirror = false;
        public bool collision = true;
        public bool drawable = false;
        public float r=0.490566f,g=0.490566f,b=0.490566f,a=1;
        public List<float> vertices;
        public List <int> triangles;
        
    }
    // game logic
    public void ReceiverCollision(GameObject ReceiverObject)
    {
        // if lights raycast collides with receiver, change state
        Receiverscript receiverscript = ReceiverObject.GetComponent<Receiverscript>();

        receiverscript.ReceivingLight = true;
    }
    private void Update()
    {
        if (Receivers.Count != 0)
        {
            CheckForComplete();
        }
    }
    void CheckForComplete()
    {
        // checks each receiver if it has reached its goal
        foreach (GameObject r in Receivers)
        {
            Receiverscript rs = r.GetComponent<Receiverscript>();

            if (!rs.on) return;
        }
        Completed();
    }
    void Completed()
    {
        GameUIscript.UI.CompletedUI();
    }

    // level instanciating logic
    void Awake()
    {
        game = this;
    }
    void Start()
    {
        // check to load in which mode
        if (RuntimeData.type == 0)
        {
            // local level
            LocalGame(RuntimeData.id);
        }
        else if (RuntimeData.type == 1)
        {
            // online level
            StartCoroutine(LoadOnlineLevelData(RuntimeData.url));
        }
        else if (RuntimeData.type == 2)
        {
            // level editor (make new level)
            if (RuntimeData.url == "" ||  RuntimeData.url == null)
            {
                
            }
        }
    }
    public void LocalGame(int levelindex)
    {
        LevelData data = LoadLocalLevelData(levelindex);
        LoadLevel(data);
    }
    // LOE !!!! HIER
    public IEnumerator LoadOnlineLevelData(string url)
    {
        // sends request to server 
        UnityWebRequest unityWebRequest = UnityWebRequest.Get(url);
        yield return unityWebRequest.SendWebRequest();
        if (unityWebRequest.result != UnityWebRequest.Result.Success)
        {
            // unity let me down
            Debug.LogWarning("Web error: "+ unityWebRequest.result);
            SceneManager.LoadScene(0);
        }
        else
        {
            // loaded JSON successfully YAY!!! Jarno = JESUS
            string json = unityWebRequest.downloadHandler.text;
            LevelData data = JsonUtility.FromJson<LevelData>(json);
            LoadLevel(data);
        }
    }
    public LevelData LoadLocalLevelData(int level)
    {
        //load data from Resource folder
        TextAsset file = Resources.Load<TextAsset>("Levels/" + level);
        LevelData data = JsonUtility.FromJson<LevelData>(file.text);
        Debug.Log("Level "+level+" data loaded!");
        return data;
    }
    // from the LevelData type, load everything into the game 
    public void LoadLevel(LevelData data)
    {
        string Name = data.name;
        float Size = data.size;

        Background.color = new Color(data.bgR, data.bgG, data.bgB, data.bgA);

        foreach (Light light in data.lights)
        {
            GameObject l = Instantiate(LightPrefab, new Vector3(light.x, light.y, Zspawn), Quaternion.identity);

            Lightscript ls = l.GetComponent<Lightscript>();

            ls.color = new Color(light.r, light.g, light.b, light.a);

            Lights.Add(l);
        }

        foreach (Receiver receiver in data.receivers)
        {
            GameObject r = Instantiate(ReceiverPrefab, new Vector3(receiver.x, receiver.y, Zspawn), Quaternion.identity);
            Receiverscript receiverscript = r.GetComponent<Receiverscript>();
            receiverscript.LightToComplete = receiver.light;

            Receivers.Add(r);
        }

        foreach (MeshObject meshObject in data.meshObjects)
        {
            List<Vector3> v = new List<Vector3>();
            for (int i = 0; i < meshObject.vertices.Count / 2; i++)
            {
                v.Add(new Vector3(meshObject.vertices[i*2],meshObject.vertices[i*2+1],Zspawn));
            }
            GameObject m = new GameObject();
            MeshFilter meshFilter = m.AddComponent<MeshFilter>();

            Mesh mesh = new Mesh();

            mesh.vertices = v.ToArray();
            mesh.triangles = meshObject.triangles.ToArray();
            mesh.RecalculateNormals();

            meshFilter.mesh = mesh;

            MeshRenderer meshRenderermr = m.AddComponent<MeshRenderer>();

            meshRenderermr.material = material;

            meshRenderermr.material.color = new Color(meshObject.r,meshObject.g,meshObject.b,meshObject.a);

            m.layer = 3;

            if (meshObject.mirror)
            {
                m.tag = "Mirror";
            }

            if (meshObject.collision)
            {
                PolygonCollider2D polygonCollider2D = m.AddComponent<PolygonCollider2D>();

                Vector2[] Points = v.Select(v => new Vector2(v.x,v.y)).ToArray();

                polygonCollider2D.SetPath(0,Points);
            }

            if (meshObject.drawable)
            {
                m.layer = LayerMask.NameToLayer("Draw");
            }
            Objects.Add(m);
        }
        foreach (Text text in data.texts)
        {
            GameObject t = Instantiate(TextPrefab, new Vector3(text.x,text.y,Zspawn), Quaternion.identity);
            TextMeshPro textMeshPro = t.GetComponent<TextMeshPro>();
            textMeshPro.text = text.text;
            textMeshPro.color = new Color(text.r, text.g, text.b, text.a);
            textMeshPro.fontSize = text.size;

            Texts.Add(t);
        }
        Debug.Log("Level "+Name+" loaded!");
    }
    // delete all the objects
    public void Clear()
    {
        Receivers.ForEach(g => Destroy(g));
        Receivers.Clear();
        Objects.ForEach(g => Destroy(g));
        Objects.Clear();
        Lights.ForEach(g => Destroy(g));
        Lights.Clear();
        Texts.ForEach(g => Destroy(g));
        Texts.Clear();
    }
}
// LOE !!! HIER
// Directories for game to communicate with the server
public static class Server
{
    // here are all the levels
    public static string url = "https://raw.githubusercontent.com/nemzzzy148/Optical_Levels/main/";
    // all the level names are here, without it the game thinks there are no levels.
    public static string table = "https://raw.githubusercontent.com/nemzzzy148/Optical_Levels/main/table.json";
}
