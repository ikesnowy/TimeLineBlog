using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLineBlog.Models
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
        /// 文章标题。
        /// </summary>
        [Display(Name = "标题")]
        [StringLength(15, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 文章的创建时间。
        /// </summary>
        [Display(Name = "创建时间")]
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 文章的最后修改时间。
        /// </summary>
        [Display(Name = "最后修改")]
        [DataType(DataType.DateTime)]
        public DateTime LastModifyTime { get; set; }

        /// <summary>
        /// 文章的 Markdown 内容。
        /// </summary>
        [Display(Name = "正文（Markdown）")]
        public string MarkdownContent { get; set; }

        /// <summary>
        /// 文章的 HTML 内容。
        /// </summary>
        [Display(Name = "正文内容")]
        public string HTMLContent { get; set; }

        /// <summary>
        /// 文章的纯文本内容。
        /// </summary>
        [Display(Name = "正文内容")]
        public string PlainContent { get; set; }
    }
}
