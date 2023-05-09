using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Click : MonoBehaviour
{
    public void Start_Game()
    {
        SceneManager.LoadScene("Level1");//Level1 isimli ekraný yükler
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Mevcut ekraný tekrar yükler
        Time.timeScale = 1;//Oyun devam eder
    }
    public void OtherScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Bir sonraki ekraný yükler
        Time.timeScale = 1;//Oyun devam eder
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");//MainMenu isimli ekraný yükler
    }
    public void QuitGame()
    {
        Application.Quit();//Oyunu kapatýr
    }
}
