using UnityEngine;

public class MyPersistentScript : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        // Do something here every frame
    }
}
