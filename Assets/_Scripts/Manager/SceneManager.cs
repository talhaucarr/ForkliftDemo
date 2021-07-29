using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using Utilities;

public class SceneManager : AutoCleanupSingleton<SceneManager>
{
    [System.Obsolete]
    public void RestartScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
