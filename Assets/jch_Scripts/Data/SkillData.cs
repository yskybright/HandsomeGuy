using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Data{
    [System.Serializable]
    public class Skill
    {
        public string skillName;
        public string description;
        public string skillType;
        public int increamentUnit;
        public float revivalHealthRatio;
        public int increamentDamage;
        public float reductionDamageRatio;
        public float increamentMoveSpeedRatio;
        public float increamentSightRange;
        public float coolTime;
        public float duration;
        public float increamentAttackSpeedRatio;
        public Type type;
        public Sprite sprite;
    }

    

    [System.Serializable]
    public class SkillData : ILoader<string, Skill>
    {
        public List<Skill> skills = new List<Skill>();
        public Dictionary<string, Skill> MakeDictionary()
        {
            Dictionary<string, Skill> skillDict = new Dictionary<string, Skill>();

            ResourceManager resourceManager = Main.ResourceManager;

            foreach (Skill skill in skills)
            {
                skillDict.Add(skill.skillName, skill);
                
                switch (skill.skillName)
                {
                    case "부활":
                        skill.type = typeof(Revival);
                        skill.sprite = resourceManager.GetResource<Sprite>("Revival.sprite");
                        break;
                    case "사디스트":
                        skill.type = typeof(Sadist);
                        skill.sprite = resourceManager.GetResource<Sprite>("Sadist.sprite");
                        break;
                    case "마조히스트":
                        skill.type = typeof(Masochist);
                        skill.sprite = resourceManager.GetResource<Sprite>("Masochist.sprite");
                        break;
                    case "헤이스트":
                        skill.type = typeof(Haste);
                        skill.sprite = resourceManager.GetResource<Sprite>("Haste.sprite");
                        break;
                    case "선택적 올빼미":
                        skill.type = typeof(ExtendSight);
                        skill.sprite = resourceManager.GetResource<Sprite>("ExtendSight.sprite");
                        break;
                    case "기계광":
                        skill.type = typeof(AlarmGimmick);
                        skill.sprite = resourceManager.GetResource<Sprite>("AlarmGimmick.sprite");
                        break;
                    case "스팀팩":
                        skill.type = typeof(SteamPack);
                        skill.sprite = resourceManager.GetResource<Sprite>("SteamPack.sprite");
                        break;
                    case "투명인간":
                        skill.type = typeof(Invisible);
                        skill.sprite = resourceManager.GetResource<Sprite>("Invisible.sprite");
                        break;
                    case "장충동 왕 족발 보쌈":
                        skill.type = typeof(JangChungDong);
                        skill.sprite = resourceManager.GetResource<Sprite>("JangChungDong.sprite");
                        break;
                }
            }

            return skillDict;
        }
    }
   

}