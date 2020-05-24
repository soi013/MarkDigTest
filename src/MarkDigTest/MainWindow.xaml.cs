using Markdig;
using Markdig.SyntaxHighlighting;
using Markdig.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarkDigTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Viewer.Pipeline = new MarkdownPipelineBuilder()
                .UseSupportedExtensions()
                .Build();

            CreateHtml();
        }

        private void CreateHtml()
        {
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseSyntaxHighlighting()
                .Build();

            string sourceText = Properties.Resources.MarkDownText;
            string markdownText = Markdig.Markdown.ToHtml(sourceText, pipeline);
            const string ouputPath = "result.html";
            File.WriteAllText(ouputPath, markdownText);
        }

        private void OpenHyperlink(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("cmd", $"/c start {e.Parameter}") { CreateNoWindow = true });
        }
    }
}
