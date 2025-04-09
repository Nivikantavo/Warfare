using UnityEngine;

public class Interacter : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // или Input.touchCount > 0
        {
            Vector3 screenPos = Input.mousePosition;

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
            screenPos = Input.GetTouch(0).position;
#endif

            Ray ray = Camera.main.ScreenPointToRay(screenPos);

            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPos);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                if(hit.collider.gameObject.TryGetComponent(out IClickInteractable interactable))
                {
                    interactable.InteractOnClick();
                }
            }
        }
    }
}
