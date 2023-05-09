using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Click : MonoBehaviour
{
    public void Start_Game()
    {
        SceneManager.LoadScene("Level1");//Level1 isimli ekran� y�kler
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Mevcut ekran� tekrar y�kler
        Time.timeScale = 1;//Oyun devam eder
    }
    public void OtherScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Bir sonraki ekran� y�kler
        Time.timeScale = 1;//Oyun devam eder
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");//MainMenu isimli ekran� y�kler
    }
    public void QuitGame()
    {
        Application.Quit();//Oyunu kapat�r
    }
}
