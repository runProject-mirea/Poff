using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] DataSaved data;
    public object ScenceManager { get; private set; }

    private void Awake()
    {
        data = FindObjectOfType<DataSaved>();
        data.getScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Retry()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
