﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Mappings
{
    public class CarLocationMap : IEntityTypeConfiguration<CarLocation>
    {
        public void Configure(EntityTypeBuilder<CarLocation> builder)
        {
            
        }
    }
}
