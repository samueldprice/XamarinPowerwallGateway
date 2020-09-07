using App1;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App1Tests
{
    public class Tests
    {
        [Test]
        public void RudimentaryServiceTest()
        {
            var testList = new List<string> { "string1", "string2" };
            var sut = new Service<List<string>>();
            var count = 0;
            var delayToken = new CancellationTokenSource();
            var delayTask = Task.Delay(-1, delayToken.Token);
            var taskKey = sut.Subscribe(list =>
            {
                count += 1;
                CollectionAssert.AreEquivalent(testList, list);
                if (count > 2)
                {
                    sut.Stop();
                    delayToken.Cancel();
                }
            });
            sut.Start(() => testList);
            Assert.Throws<TaskCanceledException>(() =>
            {
                delayTask.ConfigureAwait(false).GetAwaiter().GetResult();
            });
            Assert.GreaterOrEqual(count, 2);
        }


        [Test]
        public void Service_StartTwice_Test()
        {
            var sut = new Service<List<string>>();
            //var count = 0;
            var delayToken = new CancellationTokenSource();
            var delayTask = Task.Delay(-1, delayToken.Token);
            sut.Start(() => null);
            sut.Start(() => null);
            Task.Delay(300).GetAwaiter().GetResult();
            sut.Stop();
        }

        [Test]
        public void Service_Stop_Test()
        {
            var sut = new Service<List<string>>();
            var count = 0;
            var taskKey = sut.Subscribe(list =>
            {
                count += 1;
            });
            Task.Delay(200).GetAwaiter().GetResult();
            sut.Start(() => null);
            Task.Delay(200).GetAwaiter().GetResult();
            Assert.Greater(count, 0);
            sut.Stop();
            count = 0;
            Task.Delay(300).GetAwaiter().GetResult();
            Assert.LessOrEqual(count, 5);
        }
    }
}