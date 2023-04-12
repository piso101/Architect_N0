using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPersistentScript : MonoBehaviour
{
    private static bool isInitialized = false;

    private void Awake()
    {
        if (!isInitialized)
        {
            DontDestroyOnLoad(this.gameObject);
            PlayerPrefs.SetInt("sumarzadkosciprzedmiotow", 0);
            PlayerPrefs.SetFloat("wallet", 0);
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.SetInt("hasloaded", 1);



            
            isInitialized = true;
        }
    }

    private void Update()
    {
        // Do something here every frame
    }
}
