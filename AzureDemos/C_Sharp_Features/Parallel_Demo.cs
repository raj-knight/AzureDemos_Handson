using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Features
{
    // https://www.codeproject.com/articles/1094625/advanced-programming-with-csharp-lecture-notes-par
    internal class Parallel_Demo
    {
        public double For_Loop()
        {
            int N = 10000000;
            double sum = 0.0;
            double step = 1.0 / N;

            for (var i = 0; i < N; i++)
            {
                double x = (i + 0.5) * step;
                sum += 4.0 / (1.0 + x * x);
            }

            return sum * step;
        }

        public double For_Loop_Parallel()
        {
            object _ = new object();
            int N = 10000000;
            double sum = 0.0;
            double step = 1.0 / N;

            Parallel.For(0, N, i =>
            {
                double x = (i + 0.5) * step;
                double y = 4.0 / (1.0 + x * x);           
                lock (_)
                {
                    sum += y; 
                }
            });

            return sum * step;
        }

        public double For_Loop_Parallel_Optimized()
        {
            object _ = new object();
            int N = 10000000;
            double sum = 0.0;
            double step = 1.0 / N;

            Parallel.For(0, N,
                localInit: () => 1.0,
                body: (i, state, local) =>
                {
                    double x = (i + 0.5) * step;
                    return local + 4.0 / (1.0 + x * x);
                },
                localFinally: local =>
                {
                    lock (_)
                    {
                        sum += local;
                    }
                }); 

            return sum * step;
        }

    }
}
