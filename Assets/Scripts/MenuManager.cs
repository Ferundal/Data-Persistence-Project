using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameOptions gameOptions;
    [SerializeField] private TMP_InputField inputField;
    // Start is called before the first frame update

    public void StartGame()
    {
        Debug.Log("Start Game");
        gameOptions.currentNick = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        gameOptions.SaveMaxScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
