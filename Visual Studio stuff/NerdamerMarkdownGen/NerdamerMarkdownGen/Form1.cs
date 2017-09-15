using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jint;

namespace NerdamerMarkdownGen
{
    public partial class Form : System.Windows.Forms.Form
    {
        public static string Get(string Uri)
        {
            using (var R = WebRequest.CreateHttp(Uri).GetResponse())
            using (var S = R.GetResponseStream()) using (var Reader = new StreamReader(S))
                return Reader.ReadToEnd();
        }
        public static readonly Engine Engine = new Engine()
            .Execute("var window = new Object();")
            .Execute(Get("http://algebrite.org/dist/latest-stable/algebrite.bundle-for-browser.js"))
            .Execute(Get("https://raw.githubusercontent.com/jiggzson/nerdamer/dev/nerdamer.core.js"))
            .Execute(Get("https://raw.githubusercontent.com/jiggzson/nerdamer/dev/Algebra.js"))
            .Execute(Get("https://raw.githubusercontent.com/jiggzson/nerdamer/dev/Calculus.js"))
            .Execute(Get("https://raw.githubusercontent.com/jiggzson/nerdamer/dev/Solve.js"))
            .Execute(Get("https://raw.githubusercontent.com/jiggzson/nerdamer/dev/Extra.js"));
        public static string Eval(string In)
        {
            lock (Engine)
            {
                try { return Engine.Execute(In).GetCompletionValue().ToString(); }
                catch (Exception ex) { return 'ⓧ' + ex.Message; }
            }
        }

        public Form()
        {
            InitializeComponent();
        }

        private async void In_TextChanged(object sender, EventArgs e) => Out.Text = await Task.Run(() =>
            string.Join("\r\n", In.Lines?.Select(x => 
                (x.Contains('|') ? (x.Remove(x.IndexOf('|')), x.Substring(x.IndexOf('|') + 1)) : (x, x)))
                .Select(x => $"{x.Item1}|{x.Item2}|{Eval($"window.Algebrite.run('{x.Item1}')")}|{Eval($"nerdamer('{x.Item1}')")}")));
        
        private void Out_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = e.KeyData != (Keys.Control | Keys.C);
        }
    }
}
