using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Login_WPF
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {

            InitializeComponent();

            ScrapeMainNews();
            ScrapeBodyNews();   

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // View Expense Report
            HottestNews hottestNews = new HottestNews();
           
        }



        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {



        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }




        /**
         * ---------------------------------
           *   Scraping main front article
           *   Src: "https://www.bbc.com/";
           *   
           *   -----------------------------
           */
        private void ScrapeMainNews()
        {
            mainArticle.Clear();

            var url = "https://www.bbc.com/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var node = doc.DocumentNode.SelectSingleNode("//body");



            /**
             *   Scraping main article title
             */

            var headArticle = node.SelectSingleNode("//a[contains(@class, 'media__link')]").InnerText;

            headArticle = headArticle.Trim();

            mainArticle.AppendText(headArticle);



            /**
             *   Scraping main article image source
             */
            var imgSrc = node.SelectSingleNode("//div[contains(@class, 'responsive-image')]//img").Attributes["src"].Value;
        
            mainImage.Source = new BitmapImage(new Uri(imgSrc));
            mainImage.Width = 304;
          

            mainTextBox.Clear();
            mainTextBox.AppendText(headArticle);
        }



                /**
        * --------------------------------------
       *   Scraping Hot News
       *   ------------------------------------
       */

        private void ScrapeHotNews()
        {

            var url = "https://edition.cnn.com/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var node = doc.DocumentNode.SelectSingleNode("//strong");



            /**
             *   Scraping movies article title
             */

          //  var hotNewsArticle = node.InnerText;

          //  hotNewsArticle = hotNewsArticle.Trim();

          //  hotNewsTextBox1.Clear();
          //  hotNewsTextBox2.Clear();
          //  hotNewsTextBox3.Clear();

          //  hotNewsTextBox1.AppendText(hotNewsArticle);
          //  hotNewsTextBox2.AppendText(hotNewsArticle);
          //  hotNewsTextBox3.AppendText(hotNewsArticle);

          //  /**
          //*   Scraping movie article image source
          //*/
          //  var hotNewsImgSrc = node.SelectSingleNode("//span[contains(@class, 'story-cover-image')]//img").Attributes["src"].Value;

        }

        /**
        * --------------------------------------
       *   Scraping Movies
       *   ------------------------------------
       */

        private void ScrapeMovies()
        {

            var url = "https://www.cinemablend.com/news.php";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var node = doc.DocumentNode.SelectSingleNode("//body");



            /**
             *   Scraping movies article title
             */

            //var moviesArticle = node.SelectSingleNode("//a[contains(@class, 'title')]").InnerText;

            //moviesArticle = moviesArticle.Trim();

            //moviesTextBox1.Clear();
            //moviesTextBox2.Clear();
            //moviesTextBox3.Clear();

            //moviesTextBox1.AppendText(moviesArticle);
            //moviesTextBox2.AppendText(moviesArticle);
            //moviesTextBox3.AppendText(moviesArticle);

            /**
          *   Scraping movie article image source
          */
            //var moviesImgSrc = node.SelectSingleNode("//span[contains(@class, 'story-cover-image')]//img").Attributes["src"].Value;

        }




        /**
         * --------------------------------------
        *   Scraping news for all 9 body articles
        *   ------------------------------------
        */
        private void ScrapeBodyNews()
        {
            ScrapeHotNews();
            ScrapeMovies();   
        }
    }
}
