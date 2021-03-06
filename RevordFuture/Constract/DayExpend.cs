﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace RevordFuture.Constract
{
    [Serializable]
    public class DayExpend
    {
        public DateTime Day;
        public List<ExpendProject> Projects;

        public DayExpend()
        {
            Projects = new List<ExpendProject>();
        }

        /// <summary>
        /// 使日账目对象唯一化。
        /// </summary>
        /// <param name="dayExpends"></param>
        /// <returns></returns>
        public static List<DayExpend> MakeUnique(List<DayExpend> dayExpends)
        {
            var tool = new Dictionary<DateTime, DayExpend>();
            foreach (var dayExpend in dayExpends)
            {
                if (tool.ContainsKey(dayExpend.Day))
                {
                    tool[dayExpend.Day].Projects.AddRange(dayExpend.Projects);
                }
                else
                {
                    tool.Add(dayExpend.Day,dayExpend);
                }
            }

            var res = new List<DayExpend>();
            res.AddRange(tool.Values);
            return res;
        }

        /// <summary>
        /// 序列化为Excel数据。
        /// </summary>
        public static List<string> Serialization(List<DayExpend> dayExpends)
        {
            var list = new List<string>();
            foreach (var dayExpend in dayExpends)
            {
                foreach (var dayExpendProject in dayExpend.Projects)
                {
                    list.Add(dayExpend.Day.ToShortDateString());
                    list.Add(dayExpendProject.Name);
                    list.Add(dayExpendProject.Money.ToString());
                }
            }
            return list;
        }

        /// <summary>
        /// 反序列化excel数据。
        /// </summary>
        /// <param name="stringList"></param>
        public static List<DayExpend> Deserialization(List<string> stringList)
        {
            var dayExpendList = new List<DayExpend>();
            
            for (var i = 0; i < stringList.Count; i += 3)
            {
                dayExpendList.Add(new DayExpend()
                {
                    Day = DateParse(stringList[i]),
                    Projects = new List<ExpendProject>()
                    {
                        new ExpendProject()
                        {
                            Name = stringList[i+1],
                            Money = int.Parse(stringList[i+2])
                        }
                    }
                });
            }
            return MakeUnique(dayExpendList);
        }

        private static DateTime DateParse(string str)
        {
            var strs = str.Split('/');
            return new DateTime(int.Parse(strs[0]), int.Parse(strs[1]), int.Parse(strs[2]));
        }
    }
}
