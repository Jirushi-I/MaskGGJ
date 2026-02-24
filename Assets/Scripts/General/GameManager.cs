using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void VisibleCursor(bool isVisible) {
        Cursor.visible = isVisible;
    }
}
