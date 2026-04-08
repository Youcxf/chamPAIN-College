using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video; // needed for the background video

public class MainMenuLogic : MonoBehaviour
{
    // these are your menu folders
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    public GameObject loadingScreen;

    // these are the tabs inside the options
    public GameObject controlsTab;
    public GameObject graphicsTab;
    public GameObject audioTab;

    // the video player and the sound
    public VideoPlayer bgVideo; 
    public AudioSource clickSound;

    void Start()
    {
        // set up the menu so only main shows
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        loadingScreen.SetActive(false);

        // this part makes the video start reliably
        if (bgVideo != null)
        {
            // tell unity to get the file ready
            bgVideo.Prepare();
            // once it is ready, tell it to play automatically
            bgVideo.prepareCompleted += (source) => source.Play();
        }
    }

    public void StartButton()
    {
        if(clickSound != null) clickSound.Play();
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);
        
        // make sure your scene is named exactly "mainScene"
        SceneManager.LoadScene("mainScene");
    }

    public void OptionsButton()
    {
        if(clickSound != null) clickSound.Play();
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        
        // show audio settings first
        audioTab.SetActive(true);
        controlsTab.SetActive(false);
        graphicsTab.SetActive(false);
    }

    public void ShowControls()
    {
        if(clickSound != null) clickSound.Play();
        controlsTab.SetActive(true);
        graphicsTab.SetActive(false);
        audioTab.SetActive(false);
    }

    public void ShowGraphics()
    {
        if(clickSound != null) clickSound.Play();
        controlsTab.SetActive(false);
        graphicsTab.SetActive(true);
        audioTab.SetActive(false);
    }

    public void ShowAudio()
    {
        if(clickSound != null) clickSound.Play();
        controlsTab.SetActive(false);
        graphicsTab.SetActive(false);
        audioTab.SetActive(true);
    }

    public void CreditsButton()
    {
        if(clickSound != null) clickSound.Play();
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void BackToMenu()
    {
        if(clickSound != null) clickSound.Play();
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        if(clickSound != null) clickSound.Play();
        Application.Quit();
        // this shows in the console to prove it worked
        Debug.Log("user quit the game");
    }
}