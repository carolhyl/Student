using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 學生跟科目
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Student caroro = new Student("Caroro",
				new StudentSubject("國文", 85),
				new StudentSubject("自然", 90),
				new StudentSubject("英文", 92));

            Console.WriteLine(caroro.GetInfo());
        }
	}

	public class StudentSubject
	{
        public string SubjectName { get;private set; }
		public int Score { get;private set; }

		public StudentSubject(string subjectName, int score)
        {
			if (string.IsNullOrEmpty(subjectName))
			{
				throw new ArgumentException(subjectName, "科目名稱必填");
			}

			if(score < 0 || score > 100)
			{
				throw new ArgumentOutOfRangeException("score", $"{subjectName}分數需介於0~100");
			}
			SubjectName = subjectName;
			Score = score;
		}

		public override string ToString()
		{
			return $"{SubjectName}的成績是{Score}";
		}
	}

	public class Student
	{

		public string Name { get; private set; }
		
		public List<StudentSubject> Subjects { get; private set; }

        public Student(string name, params StudentSubject[] subjects)
        {
			Name = name;
			this.Subjects = subjects.ToList();
		}
        public string GetInfo()
		{
			//平均成績
			double _average =  this.Subjects.Average(x => x.Score);
			string average = $"平均成績是{_average}";

			//最高分
			int _highestScore = this.Subjects.Max(x => x.Score);
			string highestScore = $"最高分的科目是{_highestScore}";

			//最低分
			int _lowestScore = this.Subjects.Min(x => x.Score);
			string lowestScore = $"最高分的科目是{_lowestScore}";

			return Message(average, highestScore, lowestScore);
		}

		private string Message(string average,string highestScore,string lowestScore)
		{
			string indivudualSubject = this.Subjects
							.Select(x => x.ToString())
							.Aggregate((acc, next) => acc += ", " + next);
			string template = @"Hi {0}! 
你的{1}, 
{2}, 
{3}, 
{4}";
			string message = string.Format(template, Name, indivudualSubject, average, highestScore, lowestScore);
			return message;
		}

	}

	
}
