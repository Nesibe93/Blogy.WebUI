﻿using Blogy.DataAccessLayer.Abstract;
using Blogy.DataAccessLayer.Context;
using Blogy.DataAccessLayer.Repository;
using Blogy.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.EntityFramework
{
	public class EFArticleDal : GenericRepository<Article>, IArticleDal
	{
		BlogyContext context = new BlogyContext();

		public EFArticleDal(BlogyContext context) : base(context)
		{
		}

		public List<Article> GetArticleFilterList(string search)
        {
            var values = context.Articles.Where(x => 
			x.Title.ToLower().Contains(search.ToLower()) || 
			x.Description.ToLower().Contains(search.ToLower())).Include(x => x.Writer).ToList();
            return values;
        }

        public List<Article> GetArticlesByWriter(int id)
        {
            var values = context.Articles.Where(x=>x.AppUserId == id).ToList();
			return values;
        }

        public List<Article> GetArticlesByWriterAndCategory(int id)
        {
            var values = context.Articles.Where(x => x.AppUserId == id).Include(x => x.Category).ToList();
            return values;
        }

        public List<Article> GetArticleWithWriter()
		{
			var values = context.Articles.Include(x => x.Writer).ToList();
			return values;
		}
		public Writer GetWriterInfoByArticleWriter(int id)
		{
			var values = context.Articles.Where(x => x.ArticleId == id).Select(y => y.Writer).FirstOrDefault();
			return values;
		}
	}
}
