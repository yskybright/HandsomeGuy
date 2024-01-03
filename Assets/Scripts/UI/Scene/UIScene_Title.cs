using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIScene_Title : UIScene
{
    private enum Buttons
    {
        StartButton,
        ExitButton
    }
    private enum Images
    {
        TitleLogo
    }


    void Start()
    {
        Init();
    }

    public override bool Init()
    {
        if (!base.Init()) return false;

        BindButton(typeof(Buttons));
        BindImage(typeof(Images));

        AddUIEvent(GetButton((int)Buttons.StartButton).gameObject, OnButtonStart);
        AddUIEvent(GetButton((int)Buttons.ExitButton).gameObject, OnButtonExit);

        return true;
    }
    private void OnButtonStart(PointerEventData data)
    {
        print("시작버튼 클릭됨");
        Main.UIManager.Hide(GetButton((int)Buttons.StartButton).gameObject);
        Main.UIManager.Hide(GetButton((int)Buttons.ExitButton).gameObject);
        Main.UIManager.Hide(GetImage((int)Images.TitleLogo).gameObject);
        //Main.UIManager.CloseAllPopupUI();
        //Main.SceneManager.LoadScene("MainScene");
    }
    private void OnButtonExit(PointerEventData data)
    {
        print("나가기버튼 클릭됨");
        Application.Quit();
    }
}
