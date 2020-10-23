using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_4
{
    class Operations
    {
        public double PuassonNum(int n, double count_people)
        {
            double a = count_people;
            double[] y = new double[n];
            double[] x = new double[n];
            Random rnd = new Random();
            double p = a / n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    x[j] = rnd.NextDouble();
                }
                for (int k = 0; k < n; k++)
                {
                    if (x[k] < p)
                    {
                        y[i]++;
                    }
                }
            }
            //для проверки является ли распр. пуссона
            for (int i = 1; i < n; i++)
            {
                //  chart1.Series[0].Points.AddXY(y[i - 1], y[i]);
            }
            return y[rnd.Next(1, n)];
        }
        public double ExponentialNum(int n, double lambda)
        {
            double[] y = new double[n + 1];
            double num = -1 / lambda;
            double[] u = new double[n + 1];
            Random rnd = new Random();
            for (int i = 1; i <= n; i++)
            {
                u[i] = rnd.NextDouble();
            }
            for (int i = 1; i <= n; i++)
            {
                y[i] = Convert.ToDouble(num * Math.Log(u[i]));
            }
            //для проверки является ли показат. распр.
            for (int i = 1; i < n; i++)
            {
                //   chart1.Series[0].Points.AddXY(y[i - 1], y[i]);
            }
            return y[rnd.Next(1, n)];
        }

        public void Service(int lambda,int n, int tao)
        {
            int requests_count = lambda * 60 * 8; // 33 заявки в час за 8 часов
            var operators = new (bool busy, double free)[n];
            var requests = new (double t_coming, double t_leaving, double t_service, int oper)[requests_count];
            var queue = new List<(double t_coming, double t_leaving, double t_service, int oper)>();
            requests[0].t_service = ExponentialNum(500, 1/tao);
            requests[0].t_leaving = requests[0].t_service + requests[0].t_coming;
            requests[0].oper = 1;
            operators[0].busy = true;
            operators[0].free = requests[0].t_leaving;
            int count = 0;
            for(int i = 1; i < requests.Length; i++)
            {
                requests[i].t_coming = requests[i - 1].t_coming + PuassonNum(500,lambda);
                if (requests[i].t_coming > 480) break;
                requests[i].t_service = ExponentialNum(500, 1 / tao);
                count++;
            }
            Array.Resize(ref requests, count);
            for(int i=1; i<requests.Length; i++)
            {
                int operNum = -1;
                for(int j=0; j < operators.Length; j++)
                {
                    if (operators[j].busy == false)
                    {
                        operNum = j;
                        break;
                    }
                    if (operators[j].free <= requests[i].t_leaving)
                    {
                        operators[j].busy = false;
                        operNum = j;
                        break;
                    }
                }
                if (operNum != -1)
                {
                    requests[i].t_leaving = requests[i].t_coming + requests[i].t_service;
                    requests[i].oper = operNum + 1;
                    operators[i].busy = true;
                    operators[i].free = requests[i].t_leaving;
                }
                else
                {
                    queue.Add(requests[i]);
                }

                if (queue.Count != 0)
                {
                    double minFree =operators[0].free;
                    int index = 0;
                    for(int j = 0; j < operators.Length; j++)
                    {
                        if (operators[j].free < minFree)
                        {
                            minFree = operators[j].free;
                            index = j;
                        }
                    }
                   // queue.ElementAt(0).t_leaving = operators[index].free + queue.ElementAt(queue.Count-1).t_service;
                }
            }
        }
    }
}
