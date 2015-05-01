using System;
using System.Collections.Generic;
using System.Numerics;

class Solution {
  
  static double ComputeCorrelation(List<int> X, List<int> Y){
    int n = X.Count;
    BigInteger 
      SumXyProd = 0, 
      SumSqrX = 0, 
      SumSqrY = 0, 
      SumX = 0, 
      SumY = 0;
    
    for (int i=0; i<n; i++){
      int x = X[i], 
          y = Y[i];
      SumXyProd += x*y;
      SumSqrX += x*x;
      SumSqrY += y*y;
      SumX += x;
      SumY += y;
    }
    double 
      A = (double)((n*SumXyProd) - (SumX*SumY)),
      B = ((double)((n*SumSqrX)-(SumX*SumX))*(double)((n*SumSqrY)-(SumY*SumY)));    
    return Math.Round(A/Math.Sqrt(B),2);
  }
  
  static void Main(String[] args) {
    int N = int.Parse(Console.ReadLine());
    double a,b,c;
    List<int> 
      Math = new List<int>(),
      Physics = new List<int>(),
      Chemistry = new List<int>();
    
    for (int i=0; i<N; i++){
      string[] S = Console.ReadLine().Split('\t');
      Math.Add(int.Parse(S[0]));
      Physics.Add(int.Parse(S[1]));
      Chemistry.Add(int.Parse(S[2]));
    }    
    a = ComputeCorrelation(Math, Physics);
    b = ComputeCorrelation(Physics, Chemistry);
    c = ComputeCorrelation(Chemistry, Math);
    Console.WriteLine("{0}\n{1}\n{2}",a,b,c);
  }
}