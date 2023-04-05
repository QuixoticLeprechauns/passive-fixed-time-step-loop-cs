using System;
using System.Threading.Tasks;
namespace PassiveFixedTimeStepLoop
{
    public static class PFTS_Loop
    {
        public static async Task Invoke(Func<int> Process, int MaxSleepTime = 16, int MinSleepTime = 1)
        {
            int retval;
            async Task rproc() { retval = Process.Invoke(); await Task.Delay(MinSleepTime); };
            do
            {
                Task t = Task.Delay(MaxSleepTime); ;
                await rproc();
                await t;
            }
            while (retval != 0);
        }
    }
}