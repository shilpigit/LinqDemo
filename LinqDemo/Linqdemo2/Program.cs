using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linqdemo2
{
    class Program
    {
        public class StudentModel
        {
            public int studentID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int subID { get; set; }
        }

        public class SubjectModel
        {
            public int subjectID { get; set; }
            public string SubjectName { get; set; }
        }

        public class subMappingModel
        {
            public string SubjectName { get; set; }
            public string ExtraComment { get; set; }
        }

        static void Main(string[] args)
        {
            List<subMappingModel> subMapping = new List<subMappingModel>();
            List<SubjectModel> subDemo = new List<SubjectModel>()
            {
                new SubjectModel{subjectID=1, SubjectName="Maths"},
                new SubjectModel{subjectID=2, SubjectName="Physics"},
                new SubjectModel{subjectID=3, SubjectName="Chemistry"},
                new SubjectModel{subjectID=4, SubjectName="Biology"},
                new SubjectModel{subjectID=5, SubjectName="Botany"},
                new SubjectModel{subjectID=6, SubjectName="English"}
            };

            List<StudentModel> stuDemo = new List<StudentModel>()
            {
                new StudentModel{studentID=1, subID=1, Name="Shilpi", Age=30},
                new StudentModel{studentID=2, subID=2, Name="Surjeet", Age=28},
                new StudentModel{studentID=3, subID=3, Name="Naeem", Age=30},
                new StudentModel{studentID=4, subID=4, Name="Anas", Age=22},
                new StudentModel{studentID=5, subID=5, Name="Neha", Age=33},
                new StudentModel{studentID=6, subID=6, Name="Rekhanshi", Age=23},
                new StudentModel{studentID=7, subID=3, Name="Pushpa", Age=44},
                new StudentModel{studentID=8, subID=2, Name="Anu", Age=34},
                new StudentModel{studentID=9, subID=4, Name="Ashu", Age=22},
                new StudentModel{studentID=10, subID=1, Name="Yogesh", Age=34},
            };

            var subName = stuDemo.Select(x => new subMappingModel
            {
                SubjectName = subDemo.Where(y => y.subjectID == x.subID).FirstOrDefault().SubjectName
            }).ToList();

            var subNameOne = stuDemo.Select(x => new subMappingModel
            {
                SubjectName = subDemo.Where(y => y.subjectID == x.subID).First().SubjectName
            }).ToList();

            foreach (var subItem in subNameOne)
            {
                Console.WriteLine(subItem.SubjectName);
            }
            
            var subExtraComment = subDemo.Select(x => new subMappingModel
            {
                SubjectName = x.SubjectName,
                ExtraComment= x.SubjectName == "Chemistry" ? "Great" : null
                ////ExtraComment = subMapping.Where(y => (y.SubjectName == "Chemistry" ? y.ExtraComment = "Great" : y.ExtraComment = null))
            });
            //contains 


            List<int> studentIds = new List<int>() { 1, 2, 3, 5 };
            var studentList = stuDemo.Where(x => studentIds.Contains(x.studentID)).ToList();
            var test7 = stuDemo.Select(x => new { Tempname = x.Name, TempID = x.studentID }).ToList();//anonymous
            foreach (var item in test7)
            {
                Console.WriteLine(item.Tempname);
            }
            var test8 = stuDemo.Skip(2).Take(2);
            ////https://www.youtube.com/watch?v=cNPH6IPh5yk&t=57s
            ////https://www.youtube.com/playlist?list=PLFLBDPpXWSoI6OGnaD1_V2Eu-p3qpuvIw
        }
    }
}
