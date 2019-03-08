using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLineBlog.Models
{
    /// <summary>
    /// 文章评论。
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// 评论主键。
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 评论的文章。
        /// </summary>
        public int ArticleID { get; set; }

        /// <summary>
        /// 评论时间。
        /// </summary>
        [Display(Name = "评论时间")]
        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 评论者的昵称。
        /// </summary>
        [Display(Name = "昵称")]
        [StringLength(15, MinimumLength = 1)]
        public string NickName { get; set; }

        /// <summary>
        /// 评论的内容。
        /// </summary>
        [Required]
        [Display(Name = "评论内容")]
        [StringLength(300, MinimumLength = 1)]
        public string Content { get; set; }
    }
}
