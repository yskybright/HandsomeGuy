using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new();

    private bool _initialized;
    protected virtual void OnEnable()
    {
        Init();
    }

    public virtual bool Init()
    {
        if (_initialized) return false;

        _initialized = true;
        return true;
    }

    private void Bind<T>(Type type, bool recursive = false) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];

        for (int i = 0; i < names.Length; i++)
        {
            objects[i] = typeof(T) == typeof(GameObject) ? Util.FindChild(gameObject, names[i], recursive) : Util.FindChild<T>(gameObject, names[i], recursive);

            if (objects[i] == null)
                Debug.Log($"Failed to bind({names[i]})");
        }

        _objects.Add(typeof(T), objects);
    }

    protected void BindButton(Type type, bool recursive = false) => Bind<Button>(type, recursive);
    protected void BindImage(Type type, bool recursive = false) => Bind<Image>(type, recursive);
    protected void BindObject(Type type, bool recursive = false) => Bind<GameObject>(type, recursive);
    protected void BindText(Type type, bool recursive = false) => Bind<TextMeshProUGUI>(type, recursive);

    protected void AddUIEvent(GameObject go, Action<PointerEventData> action = null, Define.UIEvent uIEvent = Define.UIEvent.Click)
    {
        UIEventHandler uiEventHandler = Util.GetOrAddComponent<UIEventHandler>(go);


        switch (uIEvent)
        {
            case Define.UIEvent.Click:
                uiEventHandler.ClickAction -= action;
                uiEventHandler.ClickAction += action;
                break;
                //case Define.UIEvent.Drag:
                //    uiEventHandler.DragAction -= action;
                //    uiEventHandler.DragAction += action;
                //    break;
        }
    }

    private T Get<T>(int index) where T : UnityEngine.Object
    {
        if (!_objects.TryGetValue(typeof(T), out UnityEngine.Object[] objs)) return null;
        return objs[index] as T;
    }
    protected GameObject GetObject(int index) => Get<GameObject>(index);
    protected TextMeshProUGUI GetText(int index) => Get<TextMeshProUGUI>(index);
    protected Button GetButton(int index) => Get<Button>(index);
    protected Image GetImage(int index) => Get<Image>(index);
}
