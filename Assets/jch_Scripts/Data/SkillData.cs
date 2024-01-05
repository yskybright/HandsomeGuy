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
    }

    

    [System.Serializable]
    public class SkillData : ILoader<string, Skill>
    {
        public List<Skill> skills = new List<Skill>();
        public Dictionary<string, Skill> MakeDictionary()
        {
            Dictionary<string, Skill> skillDict = new Dictionary<string, Skill>();

            foreach (Skill skill in skills)
            {
                skillDict.Add(skill.skillName, skill);
                
                switch (skill.skillName)
                {
                    case "부활":
                        skill.type = typeof(Revival);
                        break;
                    case "사디스트":
                        skill.type = typeof(Sadist);
                        break;
                    case "마조히스트":
                        skill.type = typeof(Masochist);
                        break;
                    case "헤이스트":
                        skill.type = typeof(Haste);
                        break;
                    case "선택적 올빼미":
                        skill.type = typeof(ExtendSight);
                        break;
                    case "기계광":
                        skill.type = typeof(AlarmGimmick);
                        break;
                    case "스팀팩":
                        skill.type = typeof(SteamPack);
                        break;
                    case "투명인간":
                        skill.type = typeof(Invisible);
                        break;
                    //case "장충동 왕 족발 보쌈":
                    //    skill.type = typeof(Revival);
                    //    break;
                }
            }

            return skillDict;
        }
    }
   

}