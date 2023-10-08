using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CursorManager : MonoBehaviour
{
    public static CursorManager current;
    [SerializeField] Texture2D crosshairTexture;
    Vector2 cursorOffset;
    private void Awake(){
        current = this;
        cursorOffset = new Vector2(crosshairTexture.width / 2, crosshairTexture.height / 2);
        SetCursor();
    }
    public void SetCursor(){
         Cursor.SetCursor(crosshairTexture, cursorOffset, CursorMode.Auto);
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(crosshairTexture, cursorOffset, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, cursorOffset, CursorMode.Auto);
    }

    public Vector2 GetMouseDirection(GameObject obj){
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(
            worldPosition.x - obj.transform.position.x,
            worldPosition.y - obj.transform.position.y
        ).normalized;
        return direction;
    }

}
