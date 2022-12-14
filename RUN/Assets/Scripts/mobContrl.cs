using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class mobContrl : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    
    private Image joystickBG;
    [SerializeField]
    private Image joystick;
    private Vector2 inputVector;//полученные коорд джостика


    private void Start()
    {
        joystickBG = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }





    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);

    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero; //возврат джостина в центр

    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform,ped.position,ped.pressEventCamera,out pos))
        {
            pos.x = (pos.x / joystickBG.rectTransform.sizeDelta.x);//получ коорд позиц касания на джостик
            pos.y = (pos.y / joystickBG.rectTransform.sizeDelta.x);//получ коорд позиц касания на джостик

            inputVector = new Vector2(pos.x * 2 + 1, pos.y * 2 - 1);//установка точных коорд из касания
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
      
            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x *(joystickBG.rectTransform.sizeDelta.x/2), inputVector.y *(joystickBG.rectTransform.sizeDelta.y/2));
           
        }

    }

    public float Horizontal()
    {
        if (inputVector.x != 0) return inputVector.x;
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.y != 0) return inputVector.y;
        else return Input.GetAxis("Vertical");
    }
}
