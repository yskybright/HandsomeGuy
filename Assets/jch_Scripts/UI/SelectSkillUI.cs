using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : UIPopup
{
    private Dictionary<string, Type> selectSkillDict;
    private Button button1;
    private Button button2;
    private Button button3;

    public void Start()
    {
        Bind<Button>();
        selectSkillDict = new Dictionary<string, Type>
        {
            { "부활", typeof(AlarmGimmick) },
            { "방어", typeof(AlarmGimmick) },
            { "공격", typeof(AlarmGimmick) },
        };


        button1 = GetButton("Skill1Button");
        button2 = GetButton("Skill2Button");
        button3 = GetButton("Skill3Button");

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
