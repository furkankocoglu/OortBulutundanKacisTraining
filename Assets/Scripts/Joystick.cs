using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joystickOut;
    public Image joystickInside { set; get; }
    public  Vector2 yon { set; get; }
    
    // Start is called before the first frame update
    void Start()
    {
        joystickOut = GetComponent<Image>();
        joystickInside = transform.GetChild(0).GetComponent<Image>();
        yon = Vector2.zero;
        joystickInside.rectTransform.anchoredPosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickOut.rectTransform,eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / joystickOut.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickOut.rectTransform.sizeDelta.y);
            float x = (joystickOut.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y= (joystickOut.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y* 2 - 1;
            yon = new Vector2(x, y);
            yon = (yon.magnitude > 1) ? yon.normalized : yon;
            joystickInside.rectTransform.anchoredPosition = new Vector2(yon.x * (joystickOut.rectTransform.sizeDelta.x / 3), yon.y*(joystickOut.rectTransform.sizeDelta.y / 3));            
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        yon = Vector2.zero;
        joystickInside.rectTransform.anchoredPosition = Vector2.zero;
    }

}
