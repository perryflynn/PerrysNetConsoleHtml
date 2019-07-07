﻿using PerrysNetConsole;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerrysNetConsoleHtml
{
    public class CoExHtmlWriter : IDisposable
    {

        public StringWriter StringWriter { get; protected set; }
        public String HtmlTemplate { get; set; }
        public String Title { get; set; }
        public bool IsPaused { get; set; }
        public bool SuppressColors { get; set; }

        public CoExHtmlWriter()
        {
            var fullPath = System.Reflection.Assembly.GetAssembly(typeof(CoExHtmlWriter)).Location;
            var theDirectory = Path.GetDirectoryName(fullPath);
            var htmlfile = Path.Combine(theDirectory, "Asset/terminal.html");

            this.HtmlTemplate = File.ReadAllText(htmlfile);
            this.InitializeComponent();
        }

        public CoExHtmlWriter(string html)
        {
            this.HtmlTemplate = html;
            this.InitializeComponent();
        }

        public CoExHtmlWriter(FileInfo htmlfile, Encoding encoding)
        {
            this.HtmlTemplate = File.ReadAllText(htmlfile.FullName, encoding);
            this.InitializeComponent();
        }

        protected void InitializeComponent()
        {
            this.StringWriter = new StringWriter();
            if (string.IsNullOrWhiteSpace(this.Title))
            {
                this.Title = AppDomain.CurrentDomain.FriendlyName;
            }
            CoEx.OnWrite += this.OnCoExWrite;
        }

        public void Pause()
        {
            this.IsPaused = true;
        }

        public void Resume()
        {
            this.IsPaused = false;
        }

        protected void OnCoExWrite(string text)
        {
            if (this.IsPaused == false)
            {
                var format = "<span style=\"background-color:{0}; color:{1};\">{2}</span>";
                
                var bg = ColorConverter.GetHexcode(CoEx.DefaultBackgroundColor);
                var fg = ColorConverter.GetHexcode(CoEx.DefaultForegroundColor);
                
                if(this.SuppressColors == false)
                {
                    bg = ColorConverter.GetHexcode(CoEx.BackgroundColorOrDefault);
                    fg = ColorConverter.GetHexcode(CoEx.ForegroundColorOrDefault);
                }
                
                var htmltext = System.Net.WebUtility.HtmlEncode(text);
                this.StringWriter.Write(String.Format(format, bg, fg, htmltext));
            }
        }

        public void Write(string str)
        {
            this.StringWriter.Write(str);
        }

        public void Write(string format, params string[] args)
        {
            this.StringWriter.Write(String.Format(format, args));
        }

        public void WriteLine(string str)
        {
            this.StringWriter.WriteLine(str);
        }

        public void WriteLine(string format, params string[] args)
        {
            this.StringWriter.WriteLine(String.Format(format, args));
        }

        public override string ToString()
        {
            var bg = CoEx.DefaultBackgroundColor;
            if(this.SuppressColors == false)
            {
                bg = CoEx.BackgroundColorOrDefault;
            }

            if (this.StringWriter != null)
            {
                return this.HtmlTemplate
                    .Replace("{{TERMTITLE}}", this.Title)
                    .Replace("{{TERMBACKGROUND}}", ColorConverter.GetHexcode(bg))
                    .Replace("{{TERMCONTENT}}", this.StringWriter.ToString().Replace("\r", ""));
            }
            return null;
        }

        public void SaveAs(string filename)
        {
            this.SaveAs(filename, Encoding.UTF8);
        }

        public void SaveAs(string filename, Encoding enc)
        {
            File.WriteAllText(filename, this.ToString(), enc);
        }

        public void Dispose()
        {
            if (this.StringWriter != null)
            {
                this.StringWriter.Dispose();
                this.StringWriter = null;
            }
            CoEx.OnWrite -= this.OnCoExWrite;
        }
    }
}
