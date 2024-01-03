using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private int _order;
    private List<UIPopup> _popupList = new List<UIPopup>();

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }

    public T ShowPopupUI<T>(string name = null) where T : UIPopup
    {
        if (name == null)
        {
            name = typeof(T).Name;
        }

        //GameObject go = Main.ResourceManager.Load<GameObject>(name);
        //임시 오브젝트(에러 방지)
        GameObject go = new GameObject(name);
        T popupComponent = Util.GetOrAddComponent<T>(go);
        _popupList.Add(popupComponent);

        return popupComponent;
    }

    public void ClosePopupUI()
    {
        if (_popupList.Count == 0) return;

        UIPopup uIPopup = _popupList[_popupList.Count - 1];
        _popupList.RemoveAt(_popupList.Count - 1);

        //Main.ResourceManager.Destroy(uIPopup.gameObject.name);
        uIPopup = null;
    }
    public void Appear(GameObject go)
    {
        go.SetActive(true);
        Sequence seq = DOTween.Sequence();

        seq.Append(go.transform.DOScale(1.1f, 0.2f));
        seq.Append(go.transform.DOScale(1f, 0.1f));

        seq.Play();
    }
    public void Hide(GameObject go)
    {
        Sequence seq = DOTween.Sequence();

        go.transform.localScale = Vector3.one * 0.2f;

        seq.Append(go.transform.DOScale(1.1f, 0.1f));
        seq.Append(go.transform.DOScale(0.1f, 0.2f));

        seq.Play().OnComplete(() => {
            go.SetActive(false);
        });
    }
}
