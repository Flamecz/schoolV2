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



    private void Start()
    {
        OpenButton.onClick.AddListener(OpenBuildingUI);
        CloseButton.onClick.AddListener(CloseBuildingUI);
        ExitCityButton.onClick.AddListener(CloseCityView);
    }

    public void OpenBuildingUI()
    {
        OpenButton.gameObject.SetActive(false);
        BUildingsUI.SetActive(true);
        CloseButton.gameObject.SetActive(true);
        FindObjectOfType<BuildButton>().CheckStatus();
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
    public void ExitCity()
    {
        SceneManager.LoadScene(0);
    }
}
