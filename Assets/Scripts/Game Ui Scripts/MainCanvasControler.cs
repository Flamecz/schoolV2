using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvasControler : MonoBehaviour
{
    [Header("Important Resources")]
    public Button OpenButton;
    public Button CloseButton;
    public Button ExitCityButton;
    public GameObject BUildingsUI;
    public GameObject Fortress;


    private void Start()
    {
        OpenButton.onClick.AddListener(OpenBuildingUI);
        CloseButton.onClick.AddListener(CloseBuildingUI);
        ExitCityButton.onClick.AddListener(CloseAllScreens);
    }

    public void OpenBuildingUI()
    {
        OpenButton.gameObject.SetActive(false);
        BUildingsUI.SetActive(true);
        CloseButton.gameObject.SetActive(true);
    }
    public void CloseBuildingUI()
    {
        OpenButton.gameObject.SetActive(true);
        BUildingsUI.SetActive(false);
        CloseButton.gameObject.SetActive(false);
    }
    public void CloseCityView()
    {
        OpenButton.gameObject.SetActive(false);
        BUildingsUI.SetActive(false);
        CloseButton.gameObject.SetActive(false);
        ExitCity();
    }
    public void OpenFortressView()
    {
        OpenButton.gameObject.SetActive(false);
        BUildingsUI.SetActive(false);
        CloseButton.gameObject.SetActive(false);
        Fortress.gameObject.SetActive(true);
    }
    public void CloseFortressView()
    {
        OpenButton.gameObject.SetActive(false);
        BUildingsUI.SetActive(false);
        CloseButton.gameObject.SetActive(false);
        Fortress.gameObject.SetActive(false);
    }
    public void CloseAllScreens()
    {
        BUildingsUI.gameObject.SetActive(false);
        Fortress.gameObject.SetActive(false);
    }
    public void ExitCity()
    {
        FindObjectOfType<AudioManager>().Play("mainTheme");
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Stop("undeadCityTheme");
    }
}
