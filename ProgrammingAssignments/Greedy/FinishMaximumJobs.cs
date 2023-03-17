using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Greedy
{
    class FinishMaximumJobs
    {
        public int solve(List<int> A, List<int> B)
        {
            int N = A.Count;
            if (N == 1) return 1;
            var jobs = new List<Job>();
            for (int i = 0; i < N; i++)
            {
                jobs.Add(new Job(A[i], B[i]));
            }
            jobs.Sort(new JobComparer());
            int ans = 1;
            var end_t = jobs[0].EndTime;
            for (int i = 1; i < N; i++)
            {
                if (jobs[i].StartTime >= end_t)
                {
                    ans++;
                    end_t = jobs[i].EndTime;
                }
            }
            return ans;
        }
    }
    public class Job
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Job(int st_time, int end_time)
        {
            this.StartTime = st_time;
            this.EndTime = end_time;
        }
    }
    public class JobComparer : IComparer<Job>
    {
        public int Compare(Job i, Job j)
        {
            return j.EndTime - i.EndTime;
        }
    }

}
