using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] Button m_ExitButton;

    private void Start()
    {
        #if UNITY_WEBGL
                Destroy(m_ExitButton.gameObject);
        #endif
    }

    public void PlayGame()
    {
        SceneControl.Load(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
