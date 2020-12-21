using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pederli.Entity;

namespace Pederli.Data.Concrete.EntityFreamwork.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _Ids;

        public CategorySeed(int[] Ids)
        {
            _Ids = Ids;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = _Ids[0], Name = "Kalemler"},
                new Category { Id = _Ids[1], Name = "Defterler"}
            );
        }
    }
}
