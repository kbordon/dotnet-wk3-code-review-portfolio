using System;
using Portfolio.Models;

namespace Portfolio.ViewModels
{
    public class CreateComment
    {
        public Comment Comment { get; set; }
        public bool IsEntryAction { get; set; } = false;

        public CreateComment()
        {
        }
    }
}
