using Android.App.Job;
using Android.Content;
using System.Linq;

namespace App2.Droid
{
    public static class JobSchedulerHelpers
    {
        public static JobInfo.Builder CreateJobBuilderUsingJobId<T>(this Context context, int jobId) where T : JobService
        {
            var javaClass = Java.Lang.Class.FromType(typeof(T));
            var componentName = new ComponentName(context, javaClass);
            return new JobInfo.Builder(jobId, componentName);
        }
        public static bool Schedule(this Context context, JobInfo jobinfo)
        {
            var jobScheduler = (JobScheduler)context.GetSystemService(Context.JobSchedulerService);
            return jobScheduler.Schedule(jobinfo) == JobScheduler.ResultSuccess;
        }
        public static bool isRunning(this Context context, int jobId)
        {
            var jobScheduler = (JobScheduler)context.GetSystemService(Context.JobSchedulerService);
            return jobScheduler.AllPendingJobs.Any(a => a.Id == jobId); 
        }
    }
}