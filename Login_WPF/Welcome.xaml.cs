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

        List<NewsClass> hotNewsList;
        List<NewsClass> gameNewsList;
        List<NewsClass> movieNewsList;

        Grid temp;
        DispatcherTimer timer;

        double panelWidth;
        bool hidden;
        public Welcome()
        {
            InitializeComponent();

            hotNewsList = new List<NewsClass>();
            gameNewsList = new List<NewsClass>();
            movieNewsList = new List<NewsClass>();

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
            
            Button clickedButton = sender as Button;

            if (clickedButton == null) // just to be on the safe side
                return;

            if (clickedButton.Name == "HotNewsButton1")
            {
                
                temp = myGrid;
                myGrid.Children.Clear();
                Console.WriteLine("Button 1 hot news");



                TextBox newTextBox = new TextBox();
                newTextBox.Text = hotNewsList[0].Article;
                //newTextBox.TextAlignment = TextAlignment.Center; 
                //newTextBox.VerticalAlignment = VerticalAlignment.Center;
            
                newTextBox.FontSize = 42;
                //newTextBox.Margin = "39,0,62,0";
                temp.Children.Add(newTextBox);
                myGrid = temp;
                
                
   
                                          
                Console.WriteLine(hotNewsList[0].Article);

            }
            else if (clickedButton.Name == "HotNewsButton2")
            {
                Console.WriteLine("Button 2 hot news!!");
            }
            else if (clickedButton.Name == "HotNewsButton3")
            {
                Console.WriteLine("Button 3 hot news!!");
            }
            else if (clickedButton.Name == "HotNewsButton4")
            {
                Console.WriteLine("Button 4 hot news!!");
            }
            else if (clickedButton.Name == "goBackButton")
            {
                
                myGrid = temp;


  

                Console.WriteLine("goBack");
            }
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

            int numOfNews = 0;

            var url = "https://www.foxnews.com/";
            var web = new HtmlWeb();
            var doc = web.Load(url);


            /**
             *   Scraping Hot News title
             */

            String str = "//div[contains(@class, 'content')]//article[contains(@class, 'article')]//div[contains(@class, 'info')]//header[contains(@class, 'info-header')]//h2[contains(@class, 'title')]//a";
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes(str))
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


            numOfNews = -1;
            
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//img"))
            {
                String tempString = "https:" + node.Attributes["src"].Value;
                if (numOfNews == -1)
                {
                    numOfNews++;
                }
                else
                {
                    
                    hotNewsList[numOfNews].ImgSrc = tempString;
                    numOfNews++;

                }
            }

            hotNewsImg2.Source = new BitmapImage(new Uri("https://a57.foxnews.com/hp.foxnews.com/images/2020/12/480/270/37b96ab8bc2ed458aced3dc11805becd.jpg"));

      

            hotNewsImg1.Source = new BitmapImage(new Uri(hotNewsList[0].ImgSrc));
            hotNewsImg2.Source = new BitmapImage(new Uri(hotNewsList[1].ImgSrc));
            hotNewsImg3.Source = new BitmapImage(new Uri(hotNewsList[2].ImgSrc));
            hotNewsImg4.Source = new BitmapImage(new Uri(hotNewsList[3].ImgSrc));
            hotNewsImg5.Source = new BitmapImage(new Uri(hotNewsList[4].ImgSrc));
        }



        /**
     * --------------------------------------
     *   Scraping Games News
     *   src: https://www.ign.com/
     *   ------------------------------------
     */

        private void ScrapeGameNews()
        {

            int numOfNews = 0;

            var url = "https://www.ign.com/";
            var web = new HtmlWeb();
            var doc = web.Load(url);
         


            /**
             *   Scraping Game News title
             */


            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//h3"))
            {
                gameNewsList.Add(new NewsClass()); 
                gameNewsList[numOfNews++].Article = node.ChildNodes[0].InnerText.Trim();
            }


            gamesTextBox1.Clear();
            gamesTextBox2.Clear();
            gamesTextBox3.Clear();
            gamesTextBox4.Clear();
            gamesTextBox5.Clear();


            gamesTextBox1.AppendText(gameNewsList[0].Article);
            gamesTextBox2.AppendText(gameNewsList[1].Article);
            gamesTextBox3.AppendText(gameNewsList[2].Article);
            gamesTextBox4.AppendText(gameNewsList[3].Article);
            gamesTextBox5.AppendText(gameNewsList[4].Article);

            /**
              *   Scraping game article image source
              */


            numOfNews = -2;

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//img"))
            {

                String tempString = node.Attributes["src"].Value;
                if (numOfNews < 0)
                {
                    numOfNews++;
                }
                else
                {
               

                    gameNewsList[numOfNews].ImgSrc = tempString;
                    numOfNews++;
                    if (numOfNews == 5)
                        break;
                } 
               
            }


            gamesImg1.Source = new BitmapImage(new Uri(gameNewsList[0].ImgSrc));
            gamesImg2.Source = new BitmapImage(new Uri(gameNewsList[1].ImgSrc));
            gamesImg3.Source = new BitmapImage(new Uri(gameNewsList[2].ImgSrc));
            gamesImg4.Source = new BitmapImage(new Uri(gameNewsList[3].ImgSrc));
            gamesImg5.Source = new BitmapImage(new Uri(gameNewsList[4].ImgSrc));
        }










        /**
        * --------------------------------------
       *   Scraping Movies
       *   src : https://www.cinemablend.com/news.php
       *   ------------------------------------
       */

        private void ScrapeMovies()
        {

            int numOfNews = 0;

            var url = "https://www.cinemablend.com/news.php";
            var web = new HtmlWeb();
            var doc = web.Load(url);



            /**
             *   Scraping Game News title
             */


            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//span[contains(@class, 'story-related-title')]"))
            {
                movieNewsList.Add(new NewsClass());
                movieNewsList[numOfNews++].Article = node.ChildNodes[0].InnerText.Trim();
            }


            moviesTextBox1.Clear();
            moviesTextBox2.Clear();
            moviesTextBox3.Clear();
            moviesTextBox4.Clear();
            moviesTextBox5.Clear();


            moviesTextBox1.AppendText(movieNewsList[0].Article);
            moviesTextBox2.AppendText(movieNewsList[1].Article);
            moviesTextBox3.AppendText(movieNewsList[2].Article);
            moviesTextBox4.AppendText(movieNewsList[3].Article);
            moviesTextBox5.AppendText(movieNewsList[4].Article);

            /**
              *   Scraping game article image source
              */


            numOfNews = 0;

            int newsIndex = -1;
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//img"))
            {

                String tempString = node.Attributes["src"].Value;
                if (newsIndex >= 0) 
                { 
                    if (newsIndex % 2 == 0)
                    {
                        movieNewsList[numOfNews++].ImgSrc = tempString;
                      
                        if (numOfNews == 5)
                            break;
                    }

                }
                newsIndex++;
            }
            Console.WriteLine("0");
            Console.WriteLine(movieNewsList[0].ImgSrc);
            Console.WriteLine("1");
            Console.WriteLine(movieNewsList[1].ImgSrc);
            Console.WriteLine("2");
            Console.WriteLine(movieNewsList[2].ImgSrc);
            Console.WriteLine("3");
            Console.WriteLine(movieNewsList[3].ImgSrc);
            Console.WriteLine("4");
            Console.WriteLine(movieNewsList[4].ImgSrc);

            moviesImg1.Source = new BitmapImage(new Uri(movieNewsList[0].ImgSrc));
            moviesImg2.Source = new BitmapImage(new Uri(movieNewsList[1].ImgSrc));
            moviesImg3.Source = new BitmapImage(new Uri(movieNewsList[2].ImgSrc));
            moviesImg4.Source = new BitmapImage(new Uri(movieNewsList[3].ImgSrc));
            moviesImg5.Source = new BitmapImage(new Uri(movieNewsList[4].ImgSrc));
        }




        /**
         * --------------------------------------
        *   Scraping news for all 9 body articles
        *   ------------------------------------
        */
        private void ScrapeBodyNews()
        {
            ScrapeHotNews();
            ScrapeGameNews();
            ScrapeMovies();
            
        }
    }
}
