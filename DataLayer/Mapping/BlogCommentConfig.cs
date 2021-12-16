﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;


namespace DataLayer
{
   public class BlogCommentConfig:EntityTypeConfiguration<BlogComment>
    {
        public BlogCommentConfig()
        {
            ToTable("BlogComment", "Blogs");
            HasRequired(x => x.Blog).WithMany(x => x.BlogComments).HasForeignKey(x => x.BlogID)
                .WillCascadeOnDelete(false);
        }
    }
}
