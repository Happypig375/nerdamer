using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jint;
using Timer = System.Windows.Forms.Timer;

namespace NerdamerMarkdownGen
{
    public partial class Form : System.Windows.Forms.Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg,
            int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        private void Form_Shown(object sender, EventArgs e)
        {
            SendMessage(In.Handle, EM_SETCUEBANNER, 0, "Enter math expression...");
            SendMessage(Out.Handle, EM_SETCUEBANNER, 0, "Output");
        }

        public static async Task<string> Get(string Uri)
        {
            using (var R = await WebRequest.CreateHttp(Uri).GetResponseAsync())
            using (var S = R.GetResponseStream()) using (var Reader = new StreamReader(S))
                return await Reader.ReadToEndAsync();
        }
        public readonly Task<Engine> Algebrite = Task.Run(async () => new Engine()
            .Execute("var window = new Object();")
            .Execute(await Get("http://algebrite.org/dist/latest-stable/algebrite.bundle-for-browser.js")));
        public readonly Task<Engine> Nerdamer = Task.Run(async () => new Engine()
            .Execute(await Get("http://nerdamer.com/js/nerdamer.core.js"))
            .Execute(await Get("http://nerdamer.com/js/Algebra.js"))
            .Execute(await Get("http://nerdamer.com/js/Calculus.js"))
            .Execute(await Get("http://nerdamer.com/js/Solve.js"))
            .Execute(await Get("http://nerdamer.com/js/Extra.js")));
        public readonly Task<Engine> NerdamerDev = Task.Run(async () => new Engine()
            .Execute(await Get("https://raw.githubusercontent.com/jiggzson/nerdamer/dev/nerdamer.core.js"))
            .Execute(await Get("https://raw.githubusercontent.com/jiggzson/nerdamer/dev/Algebra.js"))
            .Execute(await Get("https://raw.githubusercontent.com/jiggzson/nerdamer/dev/Calculus.js"))
            .Execute(await Get("https://raw.githubusercontent.com/jiggzson/nerdamer/dev/Solve.js"))
            .Execute(await Get("https://raw.githubusercontent.com/jiggzson/nerdamer/dev/Extra.js")));
        public async Task<string> Eval(Task<Engine> Engine, string In)
        {
            var E = await Engine;
            try
            {
                return await TimeoutAfter(Task.Run(() =>
                {
                    lock (Engine) return E.Execute(In).GetCompletionValue().ToString();
                }), Time);
            }
            catch (Exception ex) { return 'ⓧ' + ex.Message; }
        }
        int NumberOfTasks = 0;
        private Timer Timer = new Timer { Interval = 50 };
        int Time = (int)TimeSpan.FromSeconds(30).TotalMilliseconds;

        public Form()
        {
            InitializeComponent();
            Timer.Tick += (sender, e) =>
            {
                // Increment the value of the ProgressBar a value of one each time.
                if (NumberOfTasks > 0) Progress.Increment(5);
                else Progress.Value = Progress.Minimum;
                // Determine if we have completed by comparing the value of the Value property to the Maximum value.
            };
            Timer.Start();
        }

        private async void In_TextChanged(object sender, EventArgs e) => Out.Text = await Task.Run(async () =>
            {
                Interlocked.Increment(ref NumberOfTasks);
                try
                {
                    var (FuncA, FuncN) = In.Lines.Take(1).Select(x => x.Contains('|') ? (x.Split('|')[0], x.Split('|')[1]) : (x, x)).Single();
                    if (string.IsNullOrWhiteSpace(FuncA)) FuncA = ".run";
                    else FuncA = "." + FuncA;
                    if (string.IsNullOrWhiteSpace(FuncN)) FuncN = "";
                    else FuncN = "." + FuncN;

                    var MyAns = In.Text.Substring(In.Text.IndexOf("\n") + 1).Contains("|");
                    var Return = $"Input|{(MyAns?"My Answer|":"")}Algebrite (@website)|Nerdamer (@demo)|Nerdamer (@dev)\r\n-{(MyAns ? "|-" : "")}|-|-|-\r\n" +
                        string.Join("\r\n", await Task.WhenAll(In.Lines?.Skip(1).Select(x =>
                       (x.Contains('|') ? (x.Remove(x.IndexOf('|')), x.Substring(x.IndexOf('|') + 1)) : (x, x)))
                       .Select(async x => $"{x.Item1}{(MyAns?"|"+x.Item2:"")}|{await Eval(Algebrite, $"window.Algebrite{FuncA}('{x.Item1}')")}|{await Eval(Nerdamer, $"nerdamer{FuncN}('{x.Item1}')")}|{await Eval(NerdamerDev, $"nerdamer('{x.Item1}')")}")))
                       .Replace("*", "\\*");
                    return Return;
                }
                finally
                {
                    Interlocked.Decrement(ref NumberOfTasks);
                }
            });
        
        private void Out_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = e.KeyData != (Keys.Control | Keys.C);
        }

        private void TimePicker_ValueChanged(object sender, EventArgs e)
        {
            Time = (int)TimePicker.Value.TimeOfDay.TotalMilliseconds;
        }

        //https://blogs.msdn.microsoft.com/pfxteam/2011/11/10/crafting-a-task-timeoutafter-method/
        [StructLayout(LayoutKind.Explicit, Size = 0)]
        struct VoidTypeStruct { }
        public static Task<T> TimeoutAfter<T>(Task<T> task, int millisecondsTimeout)
        {
            // Short-circuit #1: infinite timeout or task already completed
            if (task.IsCompleted || (millisecondsTimeout == Timeout.Infinite))
            {
                // Either the task has already completed or timeout will never occur.
                // No proxy necessary.
                return task;
            }

            // tcs.Task will be returned as a proxy to the caller
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();

            // Short-circuit #2: zero timeout
            if (millisecondsTimeout == 0)
            {
                // We've already timed out.
                tcs.SetException(new TimeoutException());
                return tcs.Task;
            }

            // Set up a timer to complete after the specified timeout period
            var timer = new System.Threading.Timer(state =>
            {
                // Recover your state information
                var myTcs = (TaskCompletionSource<T>)state;

                // Fault our proxy with a TimeoutException
                myTcs.TrySetException(new TimeoutException());
            }, tcs, millisecondsTimeout, Timeout.Infinite);

            // Wire up the logic for what happens when source task completes
            task.ContinueWith((antecedent, state) =>
            {
                // Recover our state data
                var tuple =
                    (ValueTuple<System.Threading.Timer, TaskCompletionSource<T>>)state;

                // Cancel the Timer
                tuple.Item1.Dispose();

                // Marshal results to proxy
                MarshalTaskResults(antecedent, tuple.Item2);
            },
            (timer, tcs),
            CancellationToken.None,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Default);

            return tcs.Task;
        }

        internal static void MarshalTaskResults<TResult>(Task source, TaskCompletionSource<TResult> proxy)
        {
            switch (source.Status)
            {
                case TaskStatus.Faulted:
                    proxy.TrySetException(source.Exception);
                    break;
                case TaskStatus.Canceled:
                    proxy.TrySetCanceled();
                    break;
                case TaskStatus.RanToCompletion:
                    Task<TResult> castedSource = source as Task<TResult>;
                    proxy.TrySetResult(
                        castedSource == null ? default(TResult) : // source is a Task
                            castedSource.Result); // source is a Task<TResult>
                    break;
            }
        }
    }
}
