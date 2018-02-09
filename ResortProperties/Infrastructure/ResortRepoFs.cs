using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class ResortRepoFs : IResortPostsRepo
    {
        private static List<ResortPost> _ResortRepoFs;
        private static int _nextId = 1;

        private const string PATH = "data";
        private const string FILENAME = "Blog.json";

        private readonly string _fileFullPath = Path.Combine(PATH, FILENAME);

        public ResortRepoFs()
        {
            if (_ResortRepoFs == null)
            {
                _ResortRepoFs = LoadFile();

                if (_ResortRepoFs.Count > 0)
                {
                    _nextId = _ResortRepoFs.Max(t => t.Id) + 1;
                }
            }
        }

        public void Add(ResortPost newpost)
        {
            newpost.Id = _nextId++;
            _ResortRepoFs.Add(newpost);

            SaveFile();
        }
        public void Delete(ResortPost newpost)
        {
            var origResortPost = GetById(newpost.Id);

            _ResortRepoFs.Remove(origResortPost);

            SaveFile();
        }
        public void Update(ResortPost newpost)
        {
            var newResortPost = GetById(newpost.Id);

            newResortPost.Permalink = newpost.Permalink;
            newResortPost.PhotoUrl = newpost.PhotoUrl;
            newResortPost.PostContent = newpost.PostContent;
            newResortPost.Title = newpost.Title;
            newResortPost.Author = newpost.Author;

            SaveFile();
        }
        public ResortPost GetPostByPermalink(string permalink)
        {
            return _ResortRepoFs.Find(t => t.Permalink == permalink);
        }

        public List<ResortPost> ListAll()
        {
            return _ResortRepoFs;
        }

        public ResortPost GetById(int id)
        {
            return _ResortRepoFs.Find(t => t.Id == id);
        }

        private List<ResortPost> LoadFile()
        {
            try
            {
                string rawList = File.ReadAllText(_fileFullPath);

                return JsonConvert.DeserializeObject<List<ResortPost>>(rawList);
            }
            catch (Exception)
            {
               // TODO Log the exception 
            }
            return new List<ResortPost>();
        }

        private void SaveFile()
        {
            try
            {
                if (!Directory.Exists(PATH))
                {
                    Directory.CreateDirectory(PATH);
                }
                string rawListStr = JsonConvert.SerializeObject(_ResortRepoFs);

                File.WriteAllText(_fileFullPath, rawListStr);

            }
            catch (Exception)
            {
                                
            }
        }
    }
}
