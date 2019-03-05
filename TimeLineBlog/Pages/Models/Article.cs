using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLineBlog.Pages.Models
{
    /// <summary>
    /// 博客文章的基础模型。
    /// </summary>
    public class Article
    {
        /// <summary>
        /// 文章主键。
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 文章的创建时间。
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 文章的最后修改时间。
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime LastModifyTime { get; set; }

        /// <summary>
        /// 文章的 Markdown 内容。
        /// </summary>
        public string MarkdownContent { get; set; }

        /// <summary>
        /// 文章的 HTML 内容。
        /// </summary>
        public string HTMLContent { get; set; }
    }
}
