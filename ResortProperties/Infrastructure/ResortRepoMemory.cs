using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ResortRepoMemory : IResortPostsRepo
    {
        private static List<ResortPost> _ResortPost;
        private static int _nextId = 1;
        
        public ResortRepoMemory()
        {
            if (_ResortPost == null)
            {
                _ResortPost = new List<ResortPost>();
            }
        }

        public void Add(ResortPost newResortPost)
        {
            newResortPost.Id = _nextId++;
            _ResortPost.Add(newResortPost);
        }

        public void Delete(ResortPost newPostDelete)
        {
            var origResortPost = GetById(newPostDelete.Id);

            _ResortPost.Remove(origResortPost);
        }

        public void Details(ResortPost newpost)
        {
            throw new NotImplementedException();
        }

        public void Edit(ResortPost newpost)
        {
            var newResortPost = GetById(newpost.Id);

            newResortPost.Permalink = newpost.Permalink;
            newResortPost.PhotoUrl = newpost.PhotoUrl;
            newResortPost.PostContent = newpost.PostContent;
            newResortPost.Title = newpost.Title;
            newResortPost.Author = newpost.Author;
        }

        public ResortPost GetById(int id)
        {
            return _ResortPost.Find(t => t.Id == id);
        }

        public ResortPost GetPostByPermalink(string permalink)
        {
            return _ResortPost.Find(t => t.Permalink == permalink);
        }

        public List<ResortPost> ListAll()
        {
            return _ResortPost;
        }
    }
}
