using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsgQuizzes
{
    /// <summary>
    /// HINT: Implement this methods to make all tests in QuizzesTest.cs pass
    /// </summary>
    public class Quizzes
    {
        /// Expected time to resolve: 2 minutes
        public bool IsPalindrome(string str)
        {
            string temp = str.ToLower();
            int len = temp.Length - 1;
            for (int i = 0; i <= len; i++)
            {
                if (i == len - i    //Odd
                    || len - i == 1)    // Even
                {
                    Console.WriteLine("{0} : true", str);
                    return true;
                }

                if (temp[i] != temp[len - i])
                {
                    Console.WriteLine("{0} : false", str);
                    return false;
                }
            }

            return true;
        }

        /// Expected time to resolve: 2 minutes
        public int[] GetOddNumbers(int n)
        {
            int[] result = new int[n / 2];
            for (int i = 0; i < n / 2; i++)
            {
                result[i] = (i * 2) + 1;
                Console.WriteLine(result[i]);
            }

            return result;
        }

        /// Expected time to resolve: 5 minutes
        public string[] OrderByAvgScoresDescending(IEnumerable<Exam> exams)
        {
            Dictionary<string, average> nameList = new Dictionary<string, average>();

            foreach (var e in exams)
            {
                if (!nameList.Keys.Contains(e.Student))
                {
                    average newStudent = new average(_total: e.Score);
                    nameList.Add(e.Student, newStudent);
                }
                else
                {
                    var item = nameList[e.Student];
                    item.addTotal(_total: e.Score);
                }
            }

            var names = nameList.OrderByDescending(x => x.Value.avg).Select(x => x.Key).ToArray();

            return names;
        }

        /// Expected time to resolve: 15 minutes
        public string GenerateBoard(string strInput)
        {
            var result = "";
            strInput = strInput.ToUpper();
            var input = strInput.ToCharArray();
            if (input.Length == 9)
            {

                if (!(input.Contains('X') && input.Contains('O')))
                {
                    throw new ArgumentException();
                }
                result = Environment.NewLine;
                for (int i = 0; i < 3; i++)
                {
                    result += String.Format(" {0} | {1} | {2} {3}", input[i * 3], input[i*3 + 1], input[i*3 + 2], Environment.NewLine);
                    if (i < 2)
                        result += "-----------" + Environment.NewLine;
                }
            }
            else
            {
                throw new ArgumentException();
            }
            Console.Write(result);
            return result;
        }

        /// Expected time to resolve: 60 minutes
        public int PostFixCalc(string s)
        {
            var args = s.Split(' ');

            int operand1 = 0;
            int operand2 = 0;
            int result = 0;
            string[] operators = { "+", "*", "/", "-" };

            foreach (var n in args)
            {
                if (operators.Contains(n))
                {
                    Int32.TryParse(StackImpl.values.Pop(), out operand2);
                    Int32.TryParse(StackImpl.values.Pop(), out operand1);

                    StackImpl.values.Push(evaluate(operand1, operand2, n).ToString());
                }
                else
                    StackImpl.values.Push(n);
            }
            Int32.TryParse(StackImpl.values.Peek(), out result);
            return result;
        }

        static int evaluate(int operand1, int operand2, string oper)
        {
            switch (oper)
            {
                case "+": return operand1 + operand2;
                case "*": return operand1 * operand2;
                case "/": return operand1 / operand2;
                case "-": return operand1 - operand2;
                default: return 0;
            }

        }
    }

    public class Exam
    {
        public string Student { get; set; }
        public decimal Score { get; set; }

        public Exam(string student,decimal score)
        {
            this.Student = student;
            this.Score = score;
        }
    }

    public class average
    {
        decimal total { get; set; }
        int subjects { get; set; }

        public decimal avg { get { return total / subjects; } }

        public void addTotal(decimal _total)
        {
            total = _total;
            subjects++;
        }

        public average(decimal _total)
        {
            addTotal(_total);
        }

    }

    class StackImpl
    {
        public static Stack<String> values { get; set; } = new Stack<string>();
    }

}
