using System;

namespace Newsy
{
    internal class NewsClass
    {

        public String Article { get; set; }
        public String ImgSrc { get; set; }
        public String FullBody { get; set; }


        public NewsClass()
        {
            Article = "";
            ImgSrc = "";
            FullBody = "";
        }
        public NewsClass(String article, String imgSrc, String fullBody)
        {
            this.Article = article;
            this.ImgSrc = imgSrc;
            this.FullBody = fullBody;
        }
    }
}
