using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputSwitch : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private bool isSelect = false;
    private EventSystem system;

    public Text code;

    void Start()
    {
        system = EventSystem.current;
    }
    private void SwitchInputfield()
    {
        if (code.text.Length == 1 && isSelect)
        {
            //下一个要切换到的
            Selectable next = null;
            //现在正处在能够处理事件的
            Selectable now = system.currentSelectedGameObject.GetComponent<Selectable>();
            //找到现在的下一个
            next = now.FindSelectableOnDown();
            if (next == null)
            {
                print("没有下一个了");
            }
            //让下一个能够处理事件
            system.SetSelectedGameObject(next.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        SwitchInputfield();
    }
    /// <summary>
    /// 实现ISelectHandler接口
    /// </summary>
    /// <param name="eventData"></param>
    public void OnSelect(BaseEventData eventData)
    {
        isSelect = true;
    }
    /// <summary>
    /// 实现IDeselectHandler接口
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDeselect(BaseEventData eventData)
    {
        isSelect = false;
    }

    //    EventSystem system;
    //    private bool isSelect = false;
    //    public Direction direction = Direction.horizontal;
    //    public Text code;

    //    public enum Direction
    //    {
    //        vertical = 0,
    //        horizontal = 1
    //    }

    //    // Start is called before the first frame update
    //    void Start()
    //    {
    //       // code.text = transform.Find("Text").gameObject.GetComponent<Text>().text;

    //        system = EventSystem.current;
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {
    //        if (isSelect && code.text.Length == 1)
    //        {
    //            Selectable next = null;
    //            var current = system.currentSelectedGameObject.GetComponent<Selectable>();
    //            int mark = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ? 1 : -1;
    //            Vector3 dir = direction == Direction.horizontal ? Vector3.left * mark : Vector3.up * mark;
    //            next = GetNextSelectable(current, dir);

    //            if (next != null)
    //            {
    //                var inputField = next.GetComponent<InputField>();
    //                if (inputField == null) return;
    //                StartCoroutine(Wait(next));
    //            }
    //            else
    //                return;
    //        }

    //    }


    //    private static Selectable GetNextSelectable(Selectable current, Vector3 dir)
    //    {
    //        Selectable next = current.FindSelectable(dir);
    //        if (next == null)
    //            next = current.FindLoopSelectable(-dir);
    //        return next;
    //    }

    //    IEnumerator Wait(Selectable next)
    //    {
    //        yield return new WaitForEndOfFrame();
    //        system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
    //    }

    //    public void OnSelect(BaseEventData eventData)
    //    {
    //        isSelect = true;
    //    }

    //    public void OnDeselect(BaseEventData eventData)
    //    {
    //        isSelect = false;
    //    }
    //}
    //    public static class Develop
    //    {
    //        public static Selectable FindLoopSelectable(this Selectable current, Vector3 dir)
    //        {
    //            Selectable first = current.FindSelectable(dir);
    //            if (first != null)
    //            {
    //                current = first.FindLoopSelectable(dir);
    //            }
    //            return current;
    //        }
}


