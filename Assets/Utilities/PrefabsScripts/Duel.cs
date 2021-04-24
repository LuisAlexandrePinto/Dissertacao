using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Duel : MonoBehaviour
{
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    private void OnMouseDown()
    {
        if (!IsPointerOverUIObject())
        {
            if (GameManager.Instance.CurrentPlayer.Squadron.IsReady)
            {
                SceneTransitionManager.Instance.GoToScene(SquadUpConstants.SCENE_TOWER);
            }
            else
            {
                ScreenMessage.Instance.ShowMessage(MessageColor.Dark, LanguagesFillers.Lang.NeedPlatoonReady, 2f);
            }
        }        
    }
}
