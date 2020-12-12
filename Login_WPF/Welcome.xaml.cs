using HtmlAgilityPack;
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
using System.Windows.Threading;

namespace Newsy
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        DispatcherTimer timer;

        double panelWidth;
        bool hidden;
        public Welcome()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Tick += Timer_Tick;

            panelWidth = sidePanel.Width;


            ScrapeMainNews();
            ScrapeBodyNews();
        }


        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {  
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width += 1;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 1;
                if (sidePanel.Width <= 65)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void menu_Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void PanelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        /**
         * ---------------------------------
           *   Scraping main front article
           *   Src: "https://www.bbc.com/";
           *   -----------------------------
           */
        private void ScrapeMainNews()
        {

            NewsClass mainNews = new NewsClass();

            var url = "https://www.bbc.com/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var node = doc.DocumentNode.SelectSingleNode("//body");


            /**
             *   Scraping main article title
             */

            mainNews.Article = node.SelectSingleNode("//a[contains(@class, 'media__link')]").InnerText.Trim();

            mainArticle.Clear();
            mainArticle.AppendText(mainNews.Article);

            mainTextBox.Clear();
            mainTextBox.AppendText(mainNews.Article);


            /**
             *   Scraping main article image source
             */
            mainNews.ImgSrc = node.SelectSingleNode("//div[contains(@class, 'responsive-image')]//img").Attributes["src"].Value;

            mainImage.Source = new BitmapImage(new Uri(mainNews.ImgSrc));

        }



        /**
        * --------------------------------------
        *   Scraping Hot News
        *   ------------------------------------
        */

        private void ScrapeHotNews()
        {

            List<NewsClass> hotNewsList = new List<NewsClass>();
            int numOfNews = 0;

            var url = "https://www.foxnews.com/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

          
            /**
             *   Scraping Hot News title
             */

            String str = "//div[contains(@class, 'content')]//article[contains(@class, 'article')]//div[contains(@class, 'info')]//header[contains(@class, 'info-header')]//h2[contains(@class, 'title')]//a";
            foreach(HtmlNode node in doc.DocumentNode.SelectNodes(str))
            {
                hotNewsList.Add(new NewsClass());
                hotNewsList[numOfNews++].Article = node.ChildNodes[0].InnerHtml.Trim();
            }


            hotNewsTextBox1.Clear();
            hotNewsTextBox2.Clear();
            hotNewsTextBox3.Clear();
            hotNewsTextBox4.Clear();
            hotNewsTextBox5.Clear();

            
            hotNewsTextBox1.AppendText(hotNewsList[0].Article);
            hotNewsTextBox2.AppendText(hotNewsList[1].Article);
            hotNewsTextBox3.AppendText(hotNewsList[2].Article);
            hotNewsTextBox4.AppendText(hotNewsList[3].Article);
            hotNewsTextBox5.AppendText(hotNewsList[4].Article);

              /**
                *   Scraping movie article image source
                */
          
            //hotNewsImg2.Source = new BitmapImage(new Uri(hotNewsImgSrc));
            //hotNewsImg3.Source = new BitmapImage(new Uri(hotNewsImgSrc));
        }

        /**
        * --------------------------------------
       *   Scraping Movies
       *   ------------------------------------
       */

        private void ScrapeMovies()
        {

            var url = "https://www.empireonline.com/movies/news/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var node = doc.DocumentNode.SelectSingleNode("//body");



            /**
             *   Scraping movies article title
             */

            var moviesArticle = node.SelectSingleNode("//a[contains(@class, 'title')]").InnerText;

            moviesArticle = moviesArticle.Trim();

            moviesTextBox1.Clear();
            moviesTextBox2.Clear();
            moviesTextBox3.Clear();

            moviesTextBox1.AppendText(moviesArticle);
            moviesTextBox2.AppendText(moviesArticle);
            moviesTextBox3.AppendText(moviesArticle);

            /**
              *   Scraping movie article image source
              */



            //var moviesImgSrc = node.SelectSingleNode("img[@data-test='image']").Attributes["src"].Value;

            //moviesTextBox1.Clear();
            //moviesTextBox1.AppendText(moviesImgSrc);

            //moviesImg1.Source = new BitmapImage(new Uri(moviesImgSrc));
            //moviesImg2.Source = new BitmapImage(new Uri(moviesImgSrc));
            //moviesImg3.Source = new BitmapImage(new Uri(moviesImgSrc));
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
