using System;
using System.Collections.Generic;
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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.IO;
using System.Net.Mime;


namespace dirask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int pageNumber = 1;
        int pageSize = 5;
        string snippetsType = "cs"; // C#

        int[] pageSizes = new int[] { 5, 20, 100, 250 };

        public MainWindow()
        {
            InitializeComponent();
            PageReposne response = FetchSnippets(pageNumber, pageSize, snippetsType);
            List<SnippetReponse> snippetList = new List<SnippetReponse>();
            foreach (SnippetReponse snippet in response.Batches)
                snippetList.Add(snippet);

            snippet_list.ItemsSource = snippetList;
           
        }


        public static string FetchData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                ContentType type = new ContentType(response.ContentType ?? "text/plain;charset=" + Encoding.UTF8.WebName);
                Encoding encoding = Encoding.GetEncoding(type.CharSet ?? Encoding.UTF8.WebName);

                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static PageReposne FetchSnippets(int pageNumber, int pageSize, string snippetsType)
        {
            string url = $"https://dirask.com/api/snippets?pageNumber={pageNumber}&pageSize={pageSize}&dataOrder=newest&dataGroup=batches&snippetsType={Uri.EscapeUriString(snippetsType)}";
            string data = FetchData(url);

            return JsonSerializer.Deserialize<PageReposne>(data);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void snippet_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bash_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "bash"; // C#
            PageReposne response = FetchSnippets(pageNumber, pageSize, snippetsType);
            List<SnippetReponse> snippetList = new List<SnippetReponse>();
            foreach (SnippetReponse snippet in response.Batches)
                snippetList.Add(snippet);

            snippet_list.ItemsSource = snippetList;
        }

        private void text_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "text"; // C#
            PageReposne response = FetchSnippets(pageNumber, pageSize, snippetsType);
            List<SnippetReponse> snippetList = new List<SnippetReponse>();
            foreach (SnippetReponse snippet in response.Batches)
                snippetList.Add(snippet);

            snippet_list.ItemsSource = snippetList;
        }

        private void c_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "cpp"; // C#
            PageReposne response = FetchSnippets(pageNumber, pageSize, snippetsType);
            List<SnippetReponse> snippetList = new List<SnippetReponse>();
            foreach (SnippetReponse snippet in response.Batches)
                snippetList.Add(snippet);

            snippet_list.ItemsSource = snippetList;
        }

        private void html_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "html"; // C#
            PageReposne response = FetchSnippets(pageNumber, pageSize, snippetsType);
            List<SnippetReponse> snippetList = new List<SnippetReponse>();
            foreach (SnippetReponse snippet in response.Batches)
                snippetList.Add(snippet);

            snippet_list.ItemsSource = snippetList;
        }

        private void java_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "java"; // C#
            PageReposne response = FetchSnippets(pageNumber, pageSize, snippetsType);
            List<SnippetReponse> snippetList = new List<SnippetReponse>();
            foreach (SnippetReponse snippet in response.Batches)
                snippetList.Add(snippet);

            snippet_list.ItemsSource = snippetList;
        }

        private void css_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "css"; // C#
            PageReposne response = FetchSnippets(pageNumber, pageSize, snippetsType);
            List<SnippetReponse> snippetList = new List<SnippetReponse>();
            foreach (SnippetReponse snippet in response.Batches)
                snippetList.Add(snippet);

            snippet_list.ItemsSource = snippetList;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void snippet_count_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            PageReposne response = FetchSnippets(pageNumber, pageSize, snippetsType);
            List<SnippetReponse> snippetList = new List<SnippetReponse>();
            foreach (SnippetReponse snippet in response.Batches)
                snippetList.Add(snippet);

            snippet_list.ItemsSource = snippetList;
        }
      
    }
}

public class PageReposne
{
    [JsonPropertyName("pageNumber")]
    public int PageNumber { get; set; }

    [JsonPropertyName("pagesCount")]
    public int PagesCount { get; set; }

    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }

    [JsonPropertyName("totalCount")]
    public int TotalCount { get; set; }

    [JsonPropertyName("batches")]
    public List<SnippetReponse> Batches { get; set; }
}

public class SnippetReponse
{
    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("updateTime")]
    public DateTime? UpdateTime { get; set; }
}