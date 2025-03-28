using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
        [MaxLength(255, ErrorMessage = "Title cannot be over 255 characters long")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "Content must be at least 3 characters long")]
        [MaxLength(255, ErrorMessage = "Content cannot be over 255 characters long")]
        public string Content { get; set; } = string.Empty;
    }
}