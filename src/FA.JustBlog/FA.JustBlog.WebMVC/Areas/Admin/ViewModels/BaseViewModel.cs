using FA.JustBlog.WebMVC.ViewModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.WebMVC.Areas.Admin.ViewModels
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }
    }
}