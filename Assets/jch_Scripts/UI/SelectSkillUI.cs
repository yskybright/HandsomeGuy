using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : UIPopup
{
    private enum Buttons
    {
        Skill1Button,
        Skill2Button,
        Skill3Button
    }
    private enum Images
    {
        TitleLogo
    }

    private Dictionary<string, Type> selectSkillDict;
    private Button button1;
    private Button button2;
    private Button button3;

    public void Start()
    {
        BindButton(typeof(Buttons),true);
        selectSkillDict = new Dictionary<string, Type>
        {
            { "부활", typeof(ExtendSight) },
            { "방어", typeof(ExtendSight) },
            { "공격", typeof(ExtendSight) },
        };


        button1 = GetButton((int)Buttons.Skill1Button);
        button2 = GetButton((int)Buttons.Skill2Button);
        button3 = GetButton((int)Buttons.Skill3Button);

        button1.onClick.AddListener(() => SelectSkill(button1.gameObject));
        button2.onClick.AddListener(() => SelectSkill(button2.gameObject));
        button3.onClick.AddListener(() => SelectSkill(button3.gameObject));
    }

    public void SelectSkill(GameObject go)
    {
        //BaseSkill getSkill = go.transform.parent.gameObject.GetComponent<BaseSkill>();
        //클릭된 오브젝트의 스킬 이름 정보를 가져와서 


        string skillName = "부활";

        if (selectSkillDict.TryGetValue(skillName, out Type skillType))
        {
            GameObject.Find("Player(Clone)").AddComponent(skillType);
            gameObject.SetActive(false);
        }
    }
    
}
