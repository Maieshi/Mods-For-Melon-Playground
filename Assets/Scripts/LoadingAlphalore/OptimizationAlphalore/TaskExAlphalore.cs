using System;
using System.Threading.Tasks;
public static class TaskExAlphalore
{
    /// <summary>
    /// Blocks while condition is true or timeout occurs.
    /// </summary>
    /// <param name="conditionAlphalore">The condition that will perpetuate the block.</param>
    /// <param name="frequencyAlphalore">The frequency at which the condition will be check, in milliseconds.</param>
    /// <param name="timeoutAlphalore">Timeout in milliseconds.</param>
    /// <exception cref="TimeoutException"></exception>
    /// <returns></returns>
    public static async Task WaitWhileAlphalore2(Func<bool> conditionAlphalore, int frequencyAlphalore = 25, int timeoutAlphalore = -1)
    {
        UslessClassAlphalore.UselessMethodAlphalore();
        var waitTaskAlphalore = Task.Run(async () =>
        {
            while (conditionAlphalore()) await Task.Delay(frequencyAlphalore);
        });
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();

        if (waitTaskAlphalore != await Task.WhenAny(waitTaskAlphalore, Task.Delay(timeoutAlphalore)))
            throw new TimeoutException();
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();

    }

    /// <summary>
    /// Blocks until condition is true or timeout occurs.
    /// </summary>
    /// <param name="conditionAlphalore">The break condition.</param>
    /// <param name="frequencyAlphalore">The frequency at which the condition will be checked.</param>
    /// <param name="timeoutAlphalore">The timeout in milliseconds.</param>
    /// <returns></returns>
    public static async Task WaitUntilAlphalore2(Func<bool> conditionAlphalore, int frequencyAlphalore = 25, int timeoutAlphalore = -1)
    {
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();
        bool sdfkjnhb = false;
        var waitTaskAlphalore = Task.Run(async () =>
        {
            while (!conditionAlphalore()) await Task.Delay(frequencyAlphalore);
        });

        if (waitTaskAlphalore != await Task.WhenAny(waitTaskAlphalore,
                Task.Delay(timeoutAlphalore)))
            throw new TimeoutException();
        UslessClassAlphalore.UselessMethodAlphalore(); UslessClassAlphalore.UselessMethodAlphalore();

        int asdgoiuergp = 681 + 654;

        if (sdfkjnhb)
        {
            for (int ghlojm = 0; ghlojm < 10; ghlojm++)
            {
                int ftghjta = 351;
                ftghjta *= 23;
                ftghjta /= 684;
            }
        }
    }
}