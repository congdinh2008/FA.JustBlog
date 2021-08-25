using System;
using System.Collections.Generic;

namespace FA.JustBlog.WebAPI.ViewModels
{
    public class BasicViewModel
    {
        public Guid Id { get; set; }
    }

    public class PostEditViewModel : BasicViewModel
    {
        //    {
        //"Id": "b15ce7cf-8f89-45e7-bf65-e69b71665624",
        //"Title": "Post 06",
        //"ShortDescription": "This is Post 06",
        //"ImageUrl": "blog-6.jpg",
        //"PostContent": "Content post 06",
        //"UrlSlug": "post-06",
        //"Published": true,
        //"CategoryId": "2995ffcd-9be5-4f7e-a449-96d349ea234d",
        //"TagIds": [
        //    "394ed967-c9c1-4438-902e-096a53a1ae98",
        //    "efe2f12b-d42b-4486-83c3-3351f45e7c44"
        //]
        //}
        public string Title { get; set; }
        public string Title { get; set; }
        public string Title { get; set; }
        public string Title { get; set; }
        public string Title { get; set; }

        public Guid CategoryId { get; set; }

        public List<Guid> TagIds { get; set; }
    }
}