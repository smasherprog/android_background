using Android.App;
using Android.App.Job;
using System.Threading.Tasks;

namespace App2.Droid
{
    [Service(Name = "com.companyname.App2.Droid.DownloadJob", Permission = "android.permission.BIND_JOB_SERVICE", Exported =true)]
    public class DownloadJob : JobService
    {
        public override bool OnStartJob(JobParameters jobParams)
        {
            Task.Run(() =>
            {
                // Work is happening asynchronously
                LogtoFileHelper.Write("Started background Task");
                // Have to tell the JobScheduler the work is done. 
                JobFinished(jobParams, false);
            });

            // Return true because of the asynchronous work
            return true;
        }

        public override bool OnStopJob(JobParameters jobParams)
        {
            LogtoFileHelper.Write("OnStopJob Task");
            // we don't want to reschedule the job if it is stopped or cancelled.
            return false;
        }
    }
}