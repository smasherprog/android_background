
using Android.App;
using Android.App.Job;
using Android.Content;

namespace App2.Droid
{
    public class BootBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var jobInfo = context.CreateJobBuilderUsingJobId<DownloadJob>(45)
                        .SetPeriodic(1000 * 60 * 15)//15 minutes is the smallest anways
                        .SetRequiredNetworkType(NetworkType.Any)
                        .SetPersisted(true)
                        .Build();

            if (context.Schedule(jobInfo))
            {
                LogtoFileHelper.Write("Successfully Scheduled Job");
            } else
            {
                LogtoFileHelper.Write("Failed Scheduled Job");
            }
        }
    }
}