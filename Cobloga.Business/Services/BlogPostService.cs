using AutoMapper;
using Cobloga.Business.UserStore;
using Cobloga.Business.ViewModel;
using Cobloga.Data;
using Cobloga.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cobloga.Business.Services
{
    public class BlogPostService
    {
        private IUserStore userStore;
        public BlogPostService()
        {
            this.userStore = new CoblogaUserStore();
        }

        public List<BlogPostViewModel> FetchAll()
        {
            var user = userStore.GetCurrentUser();
            using (var context = new CoblogaDataContext())
            {
                return context.CbaPost.Where(p => p.Content != null && p.Content != "" && (p.IsPublic || (user != null && p.UserId == user.Id)))
                    .Select(p => new BlogPostViewModel { Content = p.Content, CreatedDate = p.CreatedDate }).ToList();
            }
        }

        public BlogPostViewModel FetchById(Guid id)
        {

            using (var context = new CoblogaDataContext())
            {
                var model = context.CbaPost.FirstOrDefault(p => p.ID == id);
                return Mapper.Map<BlogPostViewModel>(model);
            }
        }

        public Guid Create(BlogPostViewModel viewModel)
        {
            var user = userStore.GetCurrentUser();
            using (var context = new CoblogaDataContext())
            {
                var post = new BlogPost
                {
                    UserId = user != null ? user.Id : (int?)null,
                    CreatedDate = DateTime.Now,
                    Content = viewModel.Content,
                    IsPublic = viewModel.IsPublic

                };
                post = context.CbaPost.Add(post);
                context.SaveChanges();
                return post.ID;
            }
        }

        public void Update(BlogPostViewModel viewModel)
        {   
            //TODO:Authorization
            using (var context = new CoblogaDataContext())
            {
                var entry = context.CbaPost.FirstOrDefault(p => p.ID == viewModel.ID);
                entry.Content = viewModel.Content;
                entry.IsPublic = viewModel.IsPublic;
                entry.ModifiedDate = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
