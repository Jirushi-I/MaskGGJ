using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private int counter = 0;
    public GameObject winscreen;

    public void Progress()
    {
        counter++;
        if (counter == 3)
        {
            winscreen.SetActive(true);
        }
    }
}
