using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc2
{
    class Calc
    {
        public double CountPlus(string str)
        {
            double num = 0;
            double numAft = 0;
            string strPre;
            string strAft;
            int nextOper;
            int countOper = 0;
            Console.WriteLine(str);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '+')
                {

                    for (nextOper = i + 1; nextOper < str.Length; nextOper++)
                    {
                        if (str[nextOper] == '+')
                        {
                            break;
                        }
                    }
                    if (countOper == 0)
                    {
                        strPre = str.Substring(0, i);
                        num = Convert.ToDouble(strPre);
                    }

                    strAft = str.Substring(i + 1, nextOper - i - 1);

                    numAft = Convert.ToDouble(strAft);

                    num = num + numAft;
                    countOper = countOper + 1;
                    i = nextOper-1;
                }

            }

            return num;
        }

        public double CountPlusMinus(string str)
        {
            //double numPre = 0;
            double num = 0;
            double numAft = 0;
            string strPre;
            string strAft;
            int nextOper;
            int countOper = 0; 
            Console.WriteLine(str);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '+' || str[i]=='-')
                {
                    //countOper = 1;

                    for (nextOper = i + 1; nextOper < str.Length; nextOper++)
                    {
                        if (str[nextOper] == '+' || str[nextOper] == '-')
                        {
                            break;
                        }
                    }
                    if (countOper == 0)
                    {
                        strPre = str.Substring(0, i);
                        num = Convert.ToDouble(strPre);
                    }

                    strAft = str.Substring(i + 1, nextOper - i - 1);

                    numAft = Convert.ToDouble(strAft);

                    switch (str[i])
                    {
                        case '+':
                            num = num + numAft;
                            break;
                        case '-':
                            num = num - numAft;
                            break;
                    }
                    countOper = countOper + 1;
                }
               
            }
            return num;
        }

        public double CountMultyDev(string str)
        {
            //double numPre = 0;
            double num = 0;
            double numAft = 0;
            string strPre;
            string strAft;
            int nextOper;
            int countOper=0;
            Console.WriteLine(str);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '*' || str[i] == '/')
                {

                    for (nextOper = i + 1; nextOper < str.Length; nextOper++)
                    {
                        if (str[nextOper] == '*' || str[nextOper] == '/')
                        {
                            break;
                        }
                    }
                    if (countOper == 0)
                    {
                        strPre = str.Substring(0, i);
                        num = Convert.ToDouble(strPre);
                    }

                    strAft = str.Substring(i + 1, nextOper - i - 1);

                    numAft = Convert.ToDouble(strAft);

                    switch (str[i])
                    {
                        case '*':
                            num = num * numAft;
                            break;
                        case '/':
                            num = num / numAft;
                            break;
                    }
                    countOper = countOper + 1;
                }

            }
            return num;
        }

        public double CountAll(string str)
        {
            {
                double num = 0;
                double numAft = 0;
                double numMultyDev = 0;
                string strPre;
                string strAft;
                int j = 0;
                int nextOper;
                int countOper = 0;
                bool isMultyDev = false;
                bool isEnabledMulty = true; 
                Console.WriteLine(str);
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '+' || str[i] == '-')
                    {

                        for (nextOper = i + 1; nextOper < str.Length; nextOper++)
                        {
                            if (str[nextOper] == '+' || str[nextOper] == '-')
                            {
                                break;
                            }
                            if (str[nextOper] == '*' || str[nextOper] == '/')
                            {
                                isMultyDev = true;

                                for (j = nextOper + 1; j <= str.Length; j++)
                                {

                                    if (j == str.Length)
                                    {
                                        numMultyDev = CountMultyDev(str.Substring(i + 1, j - i - 1));
                                        break;
                                    }

                                    if ((str[j] == '+' || str[j] == '-') && (str[j - 1] != '/' && str[j - 1] != '*'))
                                    {
                                        numMultyDev = CountMultyDev(str.Substring(i + 1, j - i - 1));
                                        break;
                                    }
                                    //if (str[j] == '+' || str[j] == '-') 
                                    //{
                                    //    if (str[j - 1] != '/' && str[j - 1] != '*')
                                    //    {
                                    //        numMultyDev = CountMultyDev(str.Substring(i + 1, j - i - 1));
                                    //        break;
                                    //    }

                                    //}
                                }

                                break;
                            }
                            ///////
                        }
                        if (countOper == 0)
                        {
                            strPre = str.Substring(0, i);
                            num = Convert.ToDouble(strPre);
                        }


                        if (!isMultyDev)
                        {
                            strAft = str.Substring(i + 1, nextOper - i - 1);
                            numAft = Convert.ToDouble(strAft);
                            switch (str[i])
                            {
                                case '+':
                                    num = num + numAft;
                                    break;
                                case '-':
                                    num = num - numAft;
                                    break;
                            }
                        }
                        else
                        {
                            numAft = numMultyDev;
                            switch (str[i])
                            {
                                case '+':
                                    num = num + numAft;
                                    break;
                                case '-':
                                    num = num - numAft;
                                    break;
                            }

                        }


                        if (isMultyDev)
                        {
                            i = j-1;
                        }
                        else
                        {
                            i = nextOper-1;
                        }

                        countOper = countOper + 1;
                        isMultyDev = false;
                    }
                    if ((str[i] == '*' || str[i] == '/') && (isEnabledMulty == true))
                    {

                        isMultyDev = true;

                        for (j = i + 1; j <= str.Length; j++)
                        {

                            if (j == str.Length)
                            {
                                numMultyDev = CountMultyDev(str.Substring(0, j));
                                break;
                            }

                            if (str[j] == '+' || str[j] == '-')
                            {
                                numMultyDev = CountMultyDev(str.Substring(0, j));
                                break;
                            }

                        }
                        num = numMultyDev;                      
                        isMultyDev = false;
                        isEnabledMulty = false;
                        countOper = countOper + 1;
                    }

                }
                return num;
            }
        }

        public string ClearBrackets(string str)
        {
            double result;
            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] == '(')
                {//начало скобки

                    for (int j = i + 1; j < str.Length; j++)
                    {

                        if (str[j] == ')')
                        {//конец скобки
                            result = CountAll(str.Substring(i + 1, j - i - 1));
                            str = str.Remove(i, j - i + 1);
                            str = str.Insert(i, Convert.ToString(result));
                            result = 0;
                        }//end  конец скобки

                        // Console.WriteLine(resultAfter);
                        // Console.WriteLine(str);
                    }

                }//end начало скобки

            }
            return str;
        }

        public string ClearAllBrackets(string str)
        {

            string changed;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == ')')
                {
                    for (int i = j; i >= 0; i--)
                    {
                        if (str[i] == '(')
                        {
                            changed = ClearBrackets(str.Substring(i, j - i + 1));
                            str = str.Remove(i, j - i + 1);
                            str = str.Insert(i, changed);
                            Console.WriteLine(str);
                            changed = null;
                            j = 0;
                            break;
                        }
                    }
                }
            }
            return str;
        }

        public double Count(string str)
        {
            double num = CountAll(ClearAllBrackets(str));
            return num;
        }
    }
}
