using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvasControler : MonoBehaviour
{
    [Header("Important Resources")]
    public Button OpenButton;
    public Button ExitCityButton;
    public GameObject BUildingsUI;
    public GameObject Fortress;
    public GameObject MarketPlace;
    public GameObject inventory;

    private float loadingTime = 0.5f;

    private void Start()
    {
        OpenButton.onClick.AddListener(OpenBuildingUI);
        ExitCityButton.onClick.AddListener(CloseAllScreens);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitCity();
        }
    }

    public void OpenBuildingUI()
    {
        OpenButton.gameObject.SetActive(false);
        BUildingsUI.SetActive(true);
        inventory.SetActive(false);
    }
    public void CloseBuildingUI()
    {
        OpenButton.gameObject.SetActive(true);
        BUildingsUI.SetActive(false);
        inventory.SetActive(true);
    }
    public void CloseCityView()
    {
        OpenButton.gameObject.SetActive(false);
        BUildingsUI.SetActive(false);
        ExitCity();
    }
    public void OpenFortressView()
    {
        OpenButton.gameObject.SetActive(true);
        BUildingsUI.SetActive(false);
        Fortress.gameObject.SetActive(true);
        inventory.SetActive(false);
    }
    public void CloseFortressView()
    {
        OpenButton.gameObject.SetActive(true);
        BUildingsUI.SetActive(false);
        Fortress.gameObject.SetActive(false);
        inventory.SetActive(true);
    }
    public void OpenMarketPlace()
    {
        OpenButton.gameObject.SetActive(false);
        BUildingsUI.SetActive(false);
        Fortress.gameObject.SetActive(false);
        MarketPlace.gameObject.SetActive(true);
        inventory.SetActive(false);
    }
    public void CloseMarketPlace()
    {
        OpenButton.gameObject.SetActive(false);
        BUildingsUI.SetActive(false);
        Fortress.gameObject.SetActive(false);
        MarketPlace.gameObject.SetActive(false);
        inventory.SetActive(true);
    }
    public void CloseAllScreens()
    {
        OpenButton.gameObject.SetActive(true);
        BUildingsUI.gameObject.SetActive(false);
        Fortress.gameObject.SetActive(false);
        MarketPlace.gameObject.SetActive(false);
        inventory.SetActive(true);
    }
    public void OpenAllScreens()
    {
        OpenButton.gameObject.SetActive(true);
        BUildingsUI.gameObject.SetActive(true);
        Fortress.gameObject.SetActive(true);
        MarketPlace.gameObject.SetActive(true);
        inventory.SetActive(true);
    }
    public void ExitCity()
    {
        FindObjectOfType<AudioManager>().Play("mainTheme");
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Stop("undeadCityTheme");
    }

    IEnumerator LoadAndCloseScenes()
    {
        // Loop through all scenes in the build settings
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            // Load the scene by index
            SceneManager.LoadScene(i, LoadSceneMode.Additive);

            // Wait for the specified loading time
            yield return new WaitForSeconds(loadingTime);

            // Close the loaded scene
            SceneManager.UnloadSceneAsync(i);
        }
    }
}
