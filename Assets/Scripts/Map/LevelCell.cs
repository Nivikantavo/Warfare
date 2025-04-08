using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCell : Cell
{
    protected override void Interact()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
