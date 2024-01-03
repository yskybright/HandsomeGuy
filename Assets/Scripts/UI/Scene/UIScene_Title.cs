using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIScene_Title : UIScene
{
    enum Buttons
    {
        StartButton,
        ExitButton
    }


    void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (!base.Init()) return false;

        BindButton(typeof(Buttons));

        AddUIEvent(GetButton((int)Buttons.StartButton).gameObject, OnButtonStart);
        AddUIEvent(GetButton((int)Buttons.ExitButton).gameObject, OnButtonExit);

        return true;
    }
    private void OnButtonStart(PointerEventData data)
    {
        print("시작버튼 클릭됨");
        //Main.UIManager.CloseAllPopupUI();
        //Main.SceneManager.LoadScene("MainScene");
    }
    private void OnButtonExit(PointerEventData data)
    {
        print("나가기버튼 클릭됨");
        Application.Quit();
    }
}
