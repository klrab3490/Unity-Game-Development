using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Selector() {
        SceneManager.LoadScene("selector");
    }
    public void CoinCollector() {
        SceneManager.LoadScene("level");
    }
    public void SolarSystem() {
        SceneManager.LoadScene("solarsystem");
    }
    public void ARPlane() {
        SceneManager.LoadScene("AR-Plane Traker");
    }
    public void ARFace() {
        SceneManager.LoadScene("AR Face Scene");
    }
    public void Home() {
        SceneManager.LoadScene("menu");
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}
