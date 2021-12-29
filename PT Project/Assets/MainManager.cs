using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class MainManager : MonoBehaviour
{
    // ENCAPSULATION
    public static MainManager Instance { get; private set; }

    private List<Chicken> myChickens;

    public GameObject henPrefab;
    public GameObject roosterPrefab;
    public GameObject chickPrefab;

    public void Start()
    {
        myChickens = new List<Chicken>();
    }

    public void Update()
    {
        // make a new random chicke type and make them all jump!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MakeRandomChicken();

            foreach (Chicken c in myChickens)
            {
                c.jump();
            }
        }
    }

    // ABSTRACTION
    private void MakeRandomChicken()
    {
        int chickenType = Random.Range(0, 3);

        float randomX = Random.Range(-5.0f, 5.0f);

        switch (chickenType)
        {
            case 0:
                {
                    GameObject g = Instantiate(roosterPrefab, new Vector3(randomX, 0.0f, 0.0f), roosterPrefab.transform.rotation);
                    myChickens.Add(new Rooster(g));
                    break;
                }
            case 1:
                {
                    GameObject g = Instantiate(henPrefab, new Vector3(randomX, 0.0f, 0.0f), henPrefab.transform.rotation);
                    myChickens.Add(new Hen(g));
                    break;
                }
            case 2:
                {
                    GameObject g = Instantiate(chickPrefab, new Vector3(randomX, 0.0f, 0.0f), chickPrefab.transform.rotation);
                    myChickens.Add(new Chick(g));
                    break;
                }
        }

    }

    public void StartNew()
    {
        GameObject.Find("Canvas/Start Button").SetActive(false);
        GameObject.Find("Canvas/Start Text").SetActive(false);

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
