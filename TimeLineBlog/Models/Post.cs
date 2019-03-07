using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLineBlog.Models
{
    /// <summary>
    /// 博客文章显示单位。
    /// </summary>
    public class Post
    {
        /// <summary>
        /// 博客文章。
        /// </summary>
        public Article Article { get; set; }
        /// <summary>
        /// 文章评论。
        /// </summary>
        public IEnumerable<Comment> Comments { get; set; }
    }
}
