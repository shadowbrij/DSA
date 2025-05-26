/*
Problem Description

Given a set of distinct integers A, return all possible subsets.

NOTE:

Elements in a subset must be in non-descending order.
The solution set must not contain duplicate subsets.
Also, the subsets should be sorted in ascending ( lexicographic ) order.
The initial list is not necessarily sorted.
*/
using System.Collections.Generic;

class Solution {
  List<List<int>> ans = new List<List<int>>();
    public List<List<int>> subsets(List<int> A) {
//        var ans = new List<List<int>>();
        List<int> currentSubset = new List<int>();

        ans.Add(new List<int>());
        A.Sort();
        solveSubset(A,0/*index*/,currentSubset,ans);
        //sort ans lexigraphically
        ans.Sort((a,b) => {
            int i = 0;
            while(i < a.Count && i < b.Count){
                if(a[i] != b[i]){
                    return a[i] - b[i];
                }
                i++;
            }
            return a.Count - b.Count;
        });
        return ans;
    }


    void solveSubset(List<int> A,int i,List<int> currentSubset,List<List<int>> ans){
        if(i >= A.Count){
            //currentSubset.Sort();
            ans.Add(currentSubset);
            return;
        }
        //not take
        solveSubset(A,i+1,currentSubset,ans);

        //take
        currentSubset.Add(A[i]);
        ans.Add(currentSubset);
        solveSubset(A,i+1,currentSubset,ans);

        return;
    }
}
